window.selectTab = (tabId) => {
    var tabTrigger = new bootstrap.Tab(document.querySelector('#' + tabId + 'Tab'));
    tabTrigger.show();
};
