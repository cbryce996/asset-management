// Initiate datatables in roles, tables, users page
$(Document).ready(function() {
    'use strict';
    
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
})();