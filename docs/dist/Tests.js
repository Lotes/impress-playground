"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Tests {
    static register(name, test) {
        this._tests[name] = test;
    }
    static get(name) {
        return this._tests[name];
    }
}
Tests._tests = {};
