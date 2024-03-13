public class SwitchMusic : SwitchToggleView
{
    public override int LoadDataState() => ContainerSaveerPlayerPrefs.Instance.SaveerData.IsTurnMusic;

    public override void SaveDataState(int value) => ContainerSaveerPlayerPrefs.Instance.SaveerData.IsTurnMusic = value;
}
