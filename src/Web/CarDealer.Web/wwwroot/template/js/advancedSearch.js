document.getElementById('advancedSearchBtn').addEventListener('click', (ev) => {
    ev.preventDefault();
    const hiddenArea = document.getElementById('hiddenSearchArea');
    if (hiddenArea.style.display == 'none') {
        hiddenArea.style.display = '';
    } else {
        hiddenArea.style.display = 'none';
    }
})