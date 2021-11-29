
function copytext() {
    var textarea = document.getElementById('duty');
    var text = textarea.value;
    textarea.select();
    document.execCommand('copy');
    alert('复制成功');
}
function copy(assname){

}
