using UnityEngine;
using UnityEngine.UI;

public class GateController : MonoBehaviour
{
    public OperatorEnums operatorEnums = OperatorEnums.Plus;
    [SerializeField] Text gateText;
    [SerializeField] int gateNumber;

    public int GateNumber
    {
        get => gateNumber;
    }

    private void Start()
    {
        if (operatorEnums == OperatorEnums.Plus)
            gateText.text = "+" + gateNumber.ToString();
        else if (operatorEnums == OperatorEnums.Minus)
            gateText.text = "-" + gateNumber.ToString();
        else
            gateText.text = "x" + gateNumber.ToString();
    }
}
