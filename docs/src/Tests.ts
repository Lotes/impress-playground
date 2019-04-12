import * as box2d from 'box2d.ts';

export interface Test {
  createWorld(): box2d.b2World;
  step();
}

interface TestMap {
  [name: string]: Test
}

class Tests {
  private static _tests: TestMap = {};
  static register(name: string, test: Test): void {
    this._tests[name] = test;
  }
  static get(name: string): Test {
    return this._tests[name];
  }
}
