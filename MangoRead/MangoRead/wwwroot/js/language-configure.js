var selectedLangIndex = 0;
console.log("Initialized script.");


var select = document.getElementById('lang-select');

var option_en = document.createElement('option');
option_en.value = 'en';
option_en.innerHTML = "English";

var option_ru = document.createElement('option');
option_ru.value = 'ru';
option_ru.innerHTML = 'Русский';

select.appendChild(option_en);
select.appendChild(option_ru);

select.selectedIndex = 0;

updateLang(select);

/*----------------------------------------------------------------------------------------------*/

document.getElementById('lang-select').addEventListener('change', function () {
    updateLang();
});

function updateLang() {
    select = document.getElementById('lang-select');

    selectedLangIndex = select.selectedIndex;
    console.log("current lang-index:", selectedLangIndex);

    const lang_key = select.value;
    console.log('You selected: ', select.value);

    var translate = new Translate();
    var currentLng = lang_key;
    var attributeName = 'lang-tag';
    translate.init(attributeName, currentLng);
    translate.process();
}

function setIndexToSelectLang() {
    /*document.getElementById('lang-select').selectedIndex = selectedIndexLang;
    console.log("select-lang has been updated.");*/
}

/*fetch("../Resources/Language/_keys.json")
    .then(response => {
        return response.json();
    })
    .then(jsondata => console.log(jsondata));*/

function Translate() {
    //initialization
    this.init = function (attribute, lng) {
        this.attribute = attribute;
        this.lng = lng;
    }
    //translate 
    this.process = function () {
        _self = this;
        var xrhFile = new XMLHttpRequest();
        //load content data 
        xrhFile.open("GET", "../Resources/Language/" + this.lng + ".json", false);
        xrhFile.onreadystatechange = function () {
            if (xrhFile.readyState === 4) {
                if (xrhFile.status === 200 || xrhFile.status == 0) {
                    var LngObject = JSON.parse(xrhFile.responseText);
                    var allDom = document.getElementsByTagName("*");
                    for (var i = 0; i < allDom.length; i++) {
                        var elem = allDom[i];
                        var key = elem.getAttribute(_self.attribute);

                        if (key != null) {
                            console.log(key);
                            elem.innerHTML = LngObject[key];
                        }
                    }

                }
            }
        }
        xrhFile.send();
    }
}