function butacas() {
    let celdas = [];
    //abc jkl //10 asientos
    const leters = ['A', 'B', 'C', 'J', 'K', '', 'L','M','N','O','P','','Q','R','S','T','V'];
    const row = 10;
    let tableHTML = '';
    for (let i = 1; i <= row; i++) {
        celdas[i] = [];
        tableHTML += `<tr>`;
        for (let j = 0; j < leters.length; j++) {
            if (j == 5 | j == 11)
                tableHTML += `<td style="width:80px;height:10px"></td>`;
            else {
                tableHTML += `<td class='td-modal' style="width:60px;height:40px;background-color:aquamarine"><i class="fa fa-wheelchair"></i>${i + leters[j]}</td>`;
                celdas[i][j] = i + leters[j];
            }
        }
        tableHTML += `</tr>`;
    }

    $('#modal-seats').append(tableHTML);
}


//$(document).ready(function () {
//    butacas();
//});
