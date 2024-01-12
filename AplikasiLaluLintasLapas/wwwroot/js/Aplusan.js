var dataTable;

$(document).ready(function () {
    loadDataTable();
    GetData();
});

function loadDataTable() {
    dataTable = $('#tblData2').DataTable({
        "ajax": {
            "url": "/Aplusan/GetAll"
        },
        "columns": [
            { "data": "jumlahWBP", "width": "15%" },
            { "data": "tahanan", "width": "8%" },
            { "data": "narapidana", "width": "8%" },
            { "data": "personil", "width": "9%" },
            { "data": "dariRupam", "width": "15%" },
            { "data": "keRupam", "width": "15%" },
            { "data": "tanggal", "width": "10%" },
            {

                "data": "id",
                "render": function (data) {
                    return `
            
                <div class="w-100 btn-group" role="group">

                        <a href="/Aplusan/Upsert/${data}" class="btn btn-success form-control"> <i class="bi bi-pencil-square"></i>Edit</a>

                        <button onclick=Delete("/Aplusan/Delete/${data}") class="btn btn-danger form-control" style="cursor:pointer; margin-left:10px;">
                        <i class="bi bi-trash3"></i>Delete</button>
                        
                        <a href="/Home/Print/${data}" class="btn btn-primary form-control"; style="margin-left:10px"> <i class="bi bi-printer"></i>Print</a>
 
                     </div>
                    `;

                }, "width": "20%"
            }
        ]
    });
}

function Delete(url) {
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
                        $('#tblData2').DataTable().ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

function GetData() {
    
    $.ajax({
        type: "GET",
        url: "/Home/GetData",
        //data: JSON.stringify(penilaian),
        success: function (data) {
            var data2 = JSON.stringify(data);

            var aplusan = JSON.parse(data2);

            document.getElementById("txtWBP").innerHTML = aplusan['data']['jumlahWBP'];
            document.getElementById("tanggal").innerHTML = aplusan['data']['tanggal'];
            document.getElementById("txtBonKerja").innerHTML = aplusan['data']['bonKerja'];
            document.getElementById("txtSidangTahanan").innerHTML = aplusan['data']['sidangTahanan'];
            document.getElementById("txtTahananPria").innerHTML = aplusan['data']['tahananPria'];
            document.getElementById("txtTahananWanita").innerHTML = aplusan['data']['tahananWanita'];
            document.getElementById("txtSidangNarapidana").innerHTML = aplusan['data']['sidangNarapidana'];
            document.getElementById("txtNarapidanaPria").innerHTML = aplusan['data']['narapidanaPria'];
            document.getElementById("txtNarapidanaWanita").innerHTML = aplusan['data']['narapidanaWanita'];
            document.getElementById("txtKeRupam").innerHTML = aplusan['data']['keRupam'];


        },
        error: function (data) {

            alert("GAGAL " + id);
        }
    });
}

