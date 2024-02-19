// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    loadGrid();
});


$("#frmPostTask").submit(function (e) {
    e.preventDefault();
    $(this).valid();
    var datastring = $(this).serialize();
    $.ajax({
        type: "POST",
        url: "/home/addtask",
        data: datastring,
        dataType: "json",
        success: function (data) {
            resetFields();
            loadGrid();
            $("#btnAddUpdate").text("Add Task");
        },
        error: function () {
        }
    });
});

function loadGrid() {
    $('#div_content').load('/home/GetAllTask');
}
function resetFields() {
    $("#Id").val("0");
    $("#Message").val("");
}

function deleteTask(id) {
    $.ajax({
        type: "POST",
        url: "/home/deletetask",
        data: { id: id },
        dataType: "json",
        success: function (data) {
            resetFields();
            loadGrid();
        },
        error: function () {
            alert('error handling here');
        }
    });
}

function editTask(id, msg) {
    $("#Id").val(id);
    $("#Message").val(msg);
    $("#btnAddUpdate").text("Update Task");
}

function markComplete(id) {
    $.ajax({
        type: "POST",
        url: "/home/markcomplete",
        data: { id: id },
        dataType: "json",
        success: function (data) {
            resetFields();
            loadGrid();
        },
        error: function () {
            alert('error handling here');
        }
    });
}