
let url = "https://apicorecruddepartamentosapd.azurewebsites.net/";
function getDepartamentosAsync(callBack) {
    let request = "api/departamento";
    $.ajax({
        url: url + request,
        type: "GET",
        dataType: "json",
        success: function (data) {
            callBack(data);
        }
    });
}
function convertDeptToJson(id, nombre, localidad) {
    let dept = new Object();
    dept.idDepartamento = id;
    dept.nombre = nombre;
    dept.localidad = localidad;
    var json = JSON.stringify(dept);
    return json;
}

function createDepartamentoAsync(id, nombre, localidad, callBack) {
    var json = convertDeptToJson(id, nombre, localidad);
    let request = "api/departamento";
    $.ajax({
        url: url + request,
        method: "POST",
        contentType: "application/json",
        data: json,
        success: () => {
            console.log("INSERTADO!!!!");
            callBack();
        }
    })
}
function updateDepartamentoAsync(id, nombre, localidad, callBack) {
    var json = convertDeptToJson(id, nombre, localidad);
    let request = "api/departamento";
    $.ajax({
        url: url + request,
        method: "PUT",
        contentType: "application/json",
        data: json,
        success: () => {
            console.log("INSERTADO!!!!");
            callBack();
        }
    })
}
function deleteDepartamentoAsync(id, callBack) {
    let request = "api/departamento/" + id
    $.ajax({
        url: url + request,
        method: "DELETE",
        success: function () {
            console.log("DELETEEEE!!!!!")
            loadDepartamentos()
        }
    })
}