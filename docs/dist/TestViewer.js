"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class TestViewer extends HTMLDivElement {
    constructor() {
        super();
        const shadow = this.attachShadow({ mode: 'open' });
        this.canvas = document.createElement('canvas');
        this.updateWidth(this.getAttribute('width'));
        this.updateHeight(this.getAttribute('height'));
        this.canvas.addEventListener('click', ev => {
            this.reset();
        });
        this.load(this.getAttribute('src'));
        shadow.appendChild(this.canvas);
    }
    static get observedAttributes() { return ['width', 'height', 'src']; }
    attributeChangedCallback(name, oldValue, newValue, namespaceURI) {
        switch (name) {
            case 'width':
                this.updateWidth(newValue);
                break;
            case 'height':
                this.updateHeight(newValue);
                break;
            case 'src':
                this.load(newValue);
                break;
        }
    }
    updateWidth(str) {
        console.log("wdith");
        this.canvas.setAttribute('width', str);
    }
    updateHeight(str) {
        this.canvas.setAttribute('height', str);
    }
    load(src) {
    }
    reset() {
        console.log("penis");
    }
}
window.customElements.define('test-viewer', TestViewer, { extends: 'div' });
