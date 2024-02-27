import { TuanjieLog } from '../common/TuanjieLog';
import display from '@ohos.display';
import { TuanjieMainWorker } from '../workers/TuanjieMainWorker'
import { APP_KEY_ORIENTATION_CHANGE } from '../common/Constants';

export class TuanjieDisplayInfo {
  displayID: number;
  width: number;
  height: number;
  rotation: number;
  refreshRate: number;
  densityDPI: number;
}

export class DisplayInfoManager {
  // make rotation index consistent with android
  static readonly openHarmonyToNativeRotationMap = {
    0: 0,
    1: 3,
    2: 2,
    3: 1
  };

  // todo ohos: don't support multi displayi now
  defaultDisplay: TuanjieDisplayInfo;
  private static instance = new DisplayInfoManager();

  private constructor() {
    TuanjieLog.debug('%{public}s', 'OhosSysInfo.constructor');
    this.defaultDisplay = new TuanjieDisplayInfo();
  }

  public initialize(): void {
    this.updateDisplayInfo();
    this.enableDisplayChangeCallback()
  }

  private enableDisplayChangeCallback(): void {
    let callback = (data) => {
      TuanjieLog.info('Listening enabled. Data: ' + JSON.stringify(data));
      this.updateDisplayInfo();
    };
    try {
      display.on("change", callback);
    } catch (exception) {
      TuanjieLog.error('Failed to register callback. Code: ' + JSON.stringify(exception));
    }
  }

  private updateDisplayInfo(): void {
    let displayClass = null;
    try {
      displayClass = display.getDefaultDisplaySync();
      this.defaultDisplay.displayID = displayClass.id;
      this.defaultDisplay.width = displayClass.width;
      this.defaultDisplay.height = displayClass.height;
      this.defaultDisplay.rotation = DisplayInfoManager.openHarmonyToNativeRotationMap[displayClass.rotation];
      this.defaultDisplay.refreshRate = displayClass.refreshRate;
      this.defaultDisplay.densityDPI = displayClass.densityDPI;

      AppStorage.SetOrCreate<number>(APP_KEY_ORIENTATION_CHANGE, displayClass.rotation);

      TuanjieMainWorker.getInstance().postMessage({
        type: 'SetDisplayInfo',
        data: this.defaultDisplay
      });
    }
    catch (err) {
      TuanjieLog.error('Failed to obtain the default display object. Code: ' + JSON.stringify(err));
    }
  }

  public static getInstance(): DisplayInfoManager {
    return DisplayInfoManager.instance;
  }
}