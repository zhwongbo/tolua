import sensor from '@ohos.sensor';
import { Callback } from '@ohos.base';
import tuanjie from 'libtuanjie.so';

class Msg2Unity{
    msg:string;
    err:string;

    constructor(msg:string, err:string="") {
        this.msg = msg;
        this.err = err;
    }
}

class StaticClassTest{
    // 定义一个静态方法 Call
    static Call(): void
    {
        console.log("NativeBridge StaticTestClass.Call() 方法被调用了！");
    }

    static CallX(x:number, callback: Callback<Msg2Unity>):void
    {
        console.log("NativeBridge StaticTestClass.CallX() 方法被调用了！"+x);
        callback(new Msg2Unity(x.toString(),""));
    }

    static CallInt(x:number):number{
        console.log("NativeBridge StaticTestClass.CallInt() 方法被调用了！");
        return x * x;
    }
    
    static SendMsg2Unity():void{
        console.log("NativeBridge StaticTestClass.SendMsg2Unity() 方法被调用了！");
        tuanjie.TuanjieSendMessage("Main Camera","OnMessage","test");
    }
}

class ClassTest{
    // 定义一个静态方法 Call
    Call(callback:Callback<Msg2Unity>): void
    {
        console.log("NativeBridge ClassTest.Call() 方法被调用了！");
        callback(new Msg2Unity("test callback"));
    }

    CallX(x:number, callback: Callback<Msg2Unity>):void
    {
        console.log("NativeBridge ClassTest.CallX() 方法被调用了！"+x);
        callback(new Msg2Unity(x.toString()));
    }

    CallInt(x:number):number{
        console.log("NativeBridge ClassTest.Call() 方法被调用了！");
        return x+x;
    }
}

export function RegisterNativeManager(){
    var register = {}
    register["StaticClassTest"] = StaticClassTest;
    register["ClassTest"] = new ClassTest();
    register["senor"] = sensor;
    return register
}