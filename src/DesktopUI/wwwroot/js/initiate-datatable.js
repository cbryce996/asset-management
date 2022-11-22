function initDatatable() {
    console.log("test")

    $('#systems').DataTable({
        'pageLength': 20,
        'searching': true,
        'ordering': true,
        'scrollX': true,
        'autoWidth' : false
    });

    $('#software').DataTable({
        'pageLength': 20,
        'searching': true,
        'ordering': true,
        'scrollX': true,
        'autoWidth' : false
    });
};   