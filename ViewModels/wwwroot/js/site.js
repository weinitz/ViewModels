function getAll() {
    $.get("/Ajax/GetAll", null, function (data) {
        $("#list").html(data);
        $(".delete").click(function (event) {
            event.preventDefault();
            const id = $(this).data("id");
            console.log(id)
            deleteByIntID(id)
        });
    });
}

function getByID() {
    const id = document.getElementById('IdInput').value;
    $.post("/Ajax/FindById", {id: id}, function (data) {
        $("#list").html(data);
    });
}

function deleteByIntID(id) {
    $.post("/Ajax/DeleteById", {id: id}, function (data) {

    })
        .done(function () {
            document.getElementById('errorMessages').innerHTML = "Successfully Deleted Person.";
            getAll();
        })
        .fail(function () {
            document.getElementById('errorMessages').innerHTML = "Could Not Delete Person.";
        });

}

function deleteByID() {
    const id = document.getElementById('IdInput').value;
    deleteByIntID(id)
}
