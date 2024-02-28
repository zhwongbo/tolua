
import { RegisterNativeManager } from '../NativeManager';

function register(tuanjieJSClasses, functionName) {
    var exportObj = functionName();
    for (let key of Object.keys(exportObj)) {
        tuanjieJSClasses[key] = exportObj[key];
    }
}

export function registerJSScriptToCSharp() {
    var tuanjieJSClasses = {};
    	register(tuanjieJSClasses, RegisterNativeManager);

    return tuanjieJSClasses;
}