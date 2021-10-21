if (typeof (Integration) == "undefined") { Integration = {} }
if (typeof (Integration.Dynamics) == "undefined") { Integration.Dynamics = {} }

Integration.Dynamics = {
    OnLoad: function (context) {
        this.CNPJOnChange(context);
    },
    CNPJOnChange: function (context) {
        var formContext = context.getFormContext();
        var cnpjField = "dnm2_cnpj";

        var cnpj = formContext.getAttribute(cnpjField).getValue();

        if (cnpj == "" || cnpj == null)
            return;

        cnpj = cnpj.replace(".", "").replace(".", "").replace("/", "").replace("-", "");

        if (cnpj.length != 14) {
            formContext.getAttribute(cnpjField).setValue("");
            this.DynamicsCustomAlert("Digite 14 numeros no CNPJ", "Erro de validação");
        }
        else {
            cnpj = cnpj.replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5");

            var id = Xrm.Page.data.entity.getId();
            var accountIdQuery = "";

            if (id.length > 0) {
                accountIdQuery = " and accountid ne " + id;
            }

            Xrm.WebApi.online.retrieveMultipleRecords("account", "?$select=dnm2_cnpj&$filter=dnm2_cnpj eq '" + cnpj + "'" + accountIdQuery).then(
                function success(results) {
                    if (results.entities.length > 0) {
                        formContext.getAttribute(cnpjField).setValue("");
                        Integration.Dynamics.DynamicsCustomAlert("Já existe uma conta com esse CNPJ", "CNPJ Duplicado!");
                    }
                    else {
                        formContext.getAttribute(cnpjField).setValue(cnpj);
                    }
                },
                function (error) {
                    Integration.Dynamics.DynamicsCustomAlert(error.message, "Error");
                }
            );
        }
    },
        DynamicsCustomAlert: function (alertText, alertTitle) {
            var alertStrings = {
                confirmButtonLabel: "OK",
                text: alertText,
                title: alertTitle
            };

            var alertOptions = {
                height: 120,
                width: 200
            };

            Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
        }

}
