
var dataTable;

$(document).ready(function () {
    loadDataTable();

    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }

});

function loadDataTable() {
    dataTable = $('#tblData2').DataTable({
        "ajax": {
            "url": "/BonKerja/GetAllDetail"
        },
        "columns": [
            { "data": "namaWBP", "width": "15%" },
            { "data": "jenisKelamin", "width": "10%" },
            { "data": "blok", "width": "10%" },
            { "data": "keterangan", "width": "10%" },
            {
                "data": "idDetail",
                "render": function (data) {
                    return `
               <div class="w-100 btn-group" role="group">

                        <button onclick=Delete("/BonKerja/DeleteDetail/${data}") class="btn btn-danger form-control" style="cursor:pointer; margin-left:10px;">
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
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

function trimfield(str) {
    return str.replace(/^\s+|\s+$/g, '');
}

function SaveAll() {

    var table = document.getElementById("tblData2");
    var nip = document.getElementById("txtNipKaRupam").value;
    var nama = document.getElementById("txtNamaKaRupam").value;
    var list = document.getElementById("txtListPetugas").value;
    var rowCount = table.rows.length;

    console.log(rowCount, "rr");
    console.log(nip, "apaciej");

    console.log(list, "List");

    if (trimfield(nip) == "") {
        swal({
            title: "Data Nip Ka Rupam Masih Kosong",
            //text: "Data Penanggung Jawab Masih Kosong",
            icon: "warning",
            dangerMode: true
        })
    } else if (trimfield(nama) == "") {
        swal({
            title: "Data Nama Ka Rupam Masih Kosong",
            //text: "Data Penanggung Jawab Masih Kosong",
            icon: "warning",
            dangerMode: true
        })
    } else if (trimfield(list)=='') {
        swal({
            title: "Data Keterangan Petugas Masih Kosong",
            //text: "Data Penanggung Jawab Masih Kosong",
            icon: "warning",
            dangerMode: true
        })
    }
    else if (rowCount != 1) {

        //const dataKu = list.value.replace(/(?<=(?:^|[.?!])\W*)[a-z]/g);

        const urlx = "/BonKerja/SaveAll?nip=" + nip + "&nama=" + nama + "&petugas=" + list;

        console.log(urlx, "URL");

        $.ajax({
            //type: "POST",
            url: urlx,
            success: function (data) {
                var data2 = JSON.stringify(data);

                var penilaian = JSON.parse(data2);

                //console.log(data);

                window.location = "https://localhost:7122/BonKerja/Index";

            },
            error: function (data) {

                alert("GAGAL ");
            }
        });
    } else {
        swal({
            title: "Information",
            text: "Data Bon Kerja Belum di Tambahkan",
            icon: "warning",
            dangerMode: true
        })

    }
}

function DataPetugas() {
    var x = document.getElementById("divPetugas");
    var y = document.getElementById("btnSelesai");
    var z = document.getElementById("btnCancel");

    if (x.style.display === "none") {
        x.style.display = "flex";
        y.style.display = "none"
        z.style.display = "flex"
    } else {
        x.style.display = "none";
        y.style.display = "flex"
        z.style.display = "none"
    }
}
