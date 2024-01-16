function InitCollapsibles() {
    var elems = document.querySelectorAll('.collapsible');
    var instances = M.Collapsible.init(elems, null);
}

function InitDatePickers() {
    var elems = document.querySelectorAll('.datepicker');
    var instances = M.Datepicker.init(elems, null);
}