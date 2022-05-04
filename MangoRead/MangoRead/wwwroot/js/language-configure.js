const idLangSelect = 'lang-select';

var lang = (window.hasOwnProperty('localStorage') && window.localStorage.getItem('language', lang)) || 'en';
setLanguage(lang);
document.getElementById('lang-select').value = lang;

//console.log("Selected language:", lang);

/*----------------------------------------------------------------------------------------------*/

function setLanguage(lang) {
    if (!storedLangs.hasOwnProperty(lang)) {
        return;
    }

    if (window.hasOwnProperty('localStorage')) {
        window.localStorage.setItem('language', lang);
    }

    for (var p in storedLangs[lang]) {
        var elements = document.getElementsByClassName(p);

        if (elements == null) {
            continue;
        }

        //console.log("class name:", p);
        for (var i = 0; i < elements.length; i++){
            var element = elements.item(i);
            //console.log("-", element.innerHTML);
            
            /*if (element.hasOwnProperty('value')) {
                element.value = storedLangs[lang][p];
            }*/
            if (element.hasOwnProperty('innerText')) {
                element.innerText = storedLangs[lang][p];
            }
            else {
                element.innerHTML = storedLangs[lang][p];
            }
        }        
    }
}

document.getElementById(idLangSelect).addEventListener('change', function () {
    const lang_key = this.value;
    //console.log('You selected: ', lang_key);

    if (window.hasOwnProperty('localStorage')) {
        window.localStorage.setItem('language', lang_key);
    }

    setLanguage(lang_key);
});