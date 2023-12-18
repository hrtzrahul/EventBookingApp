// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//const { isEmptyObject } = require("jquery")

// Write your JavaScript code.

funtion isEmpty(id)
{
    return document.getElementById(id).innerHTML.trim() == ""
}
console.log(isEmpty("past"));
