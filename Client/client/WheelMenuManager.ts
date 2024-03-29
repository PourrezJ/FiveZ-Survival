﻿import * as alt from 'alt-client';

let xmenuData = null;
let browser: alt.WebView = null;
let inputView: alt.WebView = null;
let callbackTime = Date.now();

export function initialize() {
    alt.onServer('WMenuManager_OpenMenu', WMenuManager_OpenMenu);
    alt.onServer('WMenuManager_CloseMenu', closeMenu);
}

function WMenuManager_OpenMenu(menu) {
    if (xmenuData != null)
        return;

    xmenuData = new Array();
    xmenuData = JSON.parse(menu);
    alt.toggleGameControls(false);
    alt.showCursor(true);

    browser = new alt.WebView('http://resource/client/cef/wheelmenu/index.html?params=' + menu, true);
    browser.focus();

    browser.on('WMenuManager_Callback', WMenuManager_Callback);
}

function WMenuManager_Callback(index) {
    const time = Date.now() - callbackTime;

    if (time < 100) {
        alt.logWarning('Double call XMenuManager_Callback: ' + time + 'ms');
        return;
    }

    callbackTime = Date.now();
    let menuItem = xmenuData.Items[index];

    // Ouverture de l'input menu
    if (menuItem.InputMaxLength > 0) {
        alt.log("Demande d'ouverture de l'input menu.");
        if (menuItem.InputValue === null) {
            menuItem.InputValue = "";
        }

        if (inputView != null) {
            inputView.destroy();
            alt.log("inputView not null ... destroy");
        }

        browser.isVisible = false;
        browser.unfocus();

        inputView = new alt.WebView("http://resource/client/cef/userinput/input.html", true);
        inputView.focus();
        alt.toggleGameControls(false);

        inputView.emit('Input_Data', menuItem.InputMaxLength, menuItem.InputValue);

        inputView.on('Input_Submit', (text) => {
            xmenuData.Items[index].InputValue = text;
            alt.emitServer("WMenuManager_ExecuteCallback", index, JSON.stringify(xmenuData));

            if (inputView != null) {
                inputView.unfocus();
                inputView.destroy();
                inputView = null;
            }

            browser.isVisible = true;
            browser.focus();
        });
    }
    else {
        // Callback serveur
        alt.emitServer("WMenuManager_ExecuteCallback", index, JSON.stringify(xmenuData));
    }

    //closeMenu();
}

function closeMenu(enableControls: boolean = true) {
    if (browser != null) {
        browser.destroy();
        browser = null;
    }
    /*
    if (inputView != null) {
        inputView.destroy();
        inputView = null;
    }
    */
    alt.toggleGameControls(true);
    alt.showCursor(false);

    xmenuData = null;
}
