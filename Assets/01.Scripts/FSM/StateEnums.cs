namespace _01.Scripts.FSM
{
    public enum StateEnums
    {
        BeRuled,
        #region Movement
        CanMove,
        Dash, 
        #endregion
        #region Health
        Hit,
        HitCool,
        Invisible,
        #endregion

        #region PlayerAttack

        FirstAttack,
        SecondAttack,
        ThirdAttack,

        #endregion

    }
}