var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/BonKerja/GetDetail"
        },
        "columns": [
            { "data": "namaWBP", "width": "15%" },
            { "data": "jenisKelamin", "width": "10%" },
            { "data": "blok", "width": "10%" },
            { "data": "keterangan", "width": "10%" }
        ]
    });
}

function Approve() {

    var id = document.getElementById("txtId").value;
    var tanggal = document.getElementById("txtTanggal").value;
    var jumlah = document.getElementById("txtJumlah").value;
    var petugas = document.getElementById("txtPetugas").value;
    var listAksi = document.getElementById("cbAksi").value;
    //var kaRupam = document.getElementById("listAksiKaRupam").value;
    //var kaRutan = document.getElementById("listAksiKaRutan").value;
    //var kasiYantah = document.getElementById("listAksiKasiYantah").value;

    // build json object
    var BonKerja = {
        Id:id,
        Tanggal: tanggal,
        Jumlah: jumlah,
        Petugas: petugas,
        TtdKaRutan: listAksi
    };

    $.ajax({
        type: "POST",
        //data: JSON.stringify(BonKerja),
        url: "/BonKerja/Approve?id=" + id + "&listAksi=" + listAksi,
        success: function (data) {

            var data2 = JSON.stringify(data);

            var penilaian = JSON.parse(data2);

            console.log(listAksi);

            //alert("SUKSES", penilaian);

        },
        error: function (data) {

            alert("GAGAL " + data);
        }
    });
}

function CetakBonKerja() {
    var id = document.getElementById("txtId").value;

    $.ajax({
        //type: "POST",
        //data: JSON.stringify(BonKerja),
        url: "/BonKerja/Print?id=" + id,
        success: function (data) {

            var data2 = JSON.stringify(data);

            var penilaian = JSON.parse(data2);

            //console.log(listAksi);

            window.location = "https://localhost:7122/BonKerja/Print?Id=" +id;

        },
        error: function (data) {

            alert("GAGAL " + data);
        }
    });
}

