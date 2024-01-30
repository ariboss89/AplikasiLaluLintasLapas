var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Wbp/GetAll"
        },
        "columns": [
            { "data": "nama", "width": "20%" },
            { "data": "nomor", "width": "10%" },
            { "data": "perkara", "width": "15%" },
            { "data": "jenisKelamin", "width": "15%" },
            { "data": "masaTahanan", "width": "10%" },
            { "data": "blokTahanan", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
               <div class="w-100">

                <a href="/Wbp/Upsert/${data}" class="col-5 btn btn-success"> <i class="bi bi-pencil-square"></i>Edit</a>

                <button onclick=Delete("/Wbp/Delete/${data}") class="col-5 btn btn-danger" style="cursor:pointer; margin-left:10px;">
                        <i class="bi bi-trash3"></i>
                        Delete</button>

                        </div>
                    `;
                }, "width": "15%"
            }
        ]
    });
}

function Delete(url) {

    //var table = $("#tblData").DataTable();

    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data !",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        $('#tblData').DataTable().ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

