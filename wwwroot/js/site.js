// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#selectAll').click(function ()
{
    if (this.checked)
    {
        /*loop*/
        $('.selectOne').each(function ()
        {
            $('.selectOne').prop('checked', true);
        });
    }
    else
    {
        $('.selectOne').each(function ()
        {
            $('.selectOne').prop('checked', false);
        });
    }
});

$('.selectOne').click(function ()
{
    if ($('.selectOne').length == $('.selectOne:checked').length)
    {
        $('#selectAll').prop('checked', true);
    }
    else
    {
        $('#selectAll').prop('checked', false);
    }
})