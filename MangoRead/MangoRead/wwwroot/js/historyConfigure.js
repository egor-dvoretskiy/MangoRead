function assignTransposition(boolValue) {
    if (window.hasOwnProperty('localStorage')) {
        window.localStorage.setItem('isPageDoubled', boolValue);
    }
}

function getBack() {
    if (window.hasOwnProperty('localStorage')) {
        let isAssigned = window.localStorage.getItem('isPageDoubled');
        if (isAssigned != null && isAssigned) {
            history.go(-2);
            assignTransposition(false);
            return;
        }
    }

    history.back();
}