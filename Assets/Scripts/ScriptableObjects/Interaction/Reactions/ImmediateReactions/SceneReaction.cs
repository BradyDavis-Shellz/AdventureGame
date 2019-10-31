public class SceneReaction : Reaction
{
    public string sceneName;
    public string startingPointInLoadedScene;
    public ISaveData playerSaveData;


    private SceneController sceneController;

    public void SetSceneController(ISceneController sceneController)
    {
        //this.sceneController = sceneController;
    }


    protected override void SpecificInit()
    {
        sceneController = FindObjectOfType<SceneController> ();
    }


    protected override void ImmediateReaction()
    {
        playerSaveData.Save (PlayerMovement.startingPositionKey, startingPointInLoadedScene);
        sceneController.FadeAndLoadScene (this);
    }
}