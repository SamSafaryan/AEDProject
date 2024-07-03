function FillDocTypes(lstCountry, lstDocTypeId) {
    var lstDocTypes = $("#" + lstDocTypeId);
    $("#DocumentTypeId").empty();
    $("#DocumentTypeId").append("<option value=''>" +"Select" + "</option>")
    var selectedCountry = lstCountry.options[lstCountry.selectedIndex].value;

    if (selectedCountry != null && selectedCountry != '') {
        $.getJSON("/Home/GetDocTypesByCountryId", { countryid: selectedCountry }, function (data) {
            if (data != null && !jQuery.isEmptyObject(data)) {
                $.each(data, function (index, model) {
                    $("#DocumentTypeId").append("<option value='" + model.id+"'>" + model.name+"</option>")
                });
            }
        });
    }
}