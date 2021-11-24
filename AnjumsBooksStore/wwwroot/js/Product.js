var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "name"},
            { "data": "title"},
            { "data": "author"},
            { "data": "lastprice"},
            { "data": "categoryname"},
            { "data": "covertypename"},
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Product/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>&nbsp;
                                </a>
                                <a href="/Admin/Product/Delete/${data}" class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i>&nbsp;
                                </a>
                            </div>
                            `;
                }, "width": "40%"
            }
        ]
    });
}