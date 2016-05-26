$(document).ready(function () {
    hide_all_dpmt();
    hide_all_item();

    $('#dpmt_button').click(function () {
        on_dpmt_button();
    });

    $('#item_button').click(function () {
        on_item_button();
    });

    $('#sel_dpmt').change(function () {
        $('#item_changes').show();
    })
});

hide_all_dpmt = function () {
    $('.for_dpmt').hide();
    $('#dpmt_changes').hide();
};

hide_all_item = function () {
    $('.for_item').hide();
    $('#departments').hide();
    $('#sel_dpmt').hide();
    $('#item_changes').hide();
};

on_dpmt_button = function () {
    hide_all_dpmt();
    hide_all_item();
    $('.for_dpmt').show();
    $('#dpmt_changes').show();
};

on_item_button = function () {
    hide_all_item();
    hide_all_dpmt();
    $('.for_item').show();
    $('#sel_dpmt').show();
}


