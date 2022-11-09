// Initiate datatables in roles, tables, users page
$(Document).ready(function() {
    'use strict';
    
    $('#dataTables-example').DataTable({
        'pageLength': 20,
        'searching': true,
        'ordering': true,
        'scrollX': true,
        'autoWidth' : false
    });
})();