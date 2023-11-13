using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
	private Slider slider;

	private void Start()
	{
		slider = GetComponentInChildren<Slider>();
		slider.value = slider.maxValue;
		GetComponentInParent<IHealth>().OnHPPctChanged += HandleHPPctChanged;
	}

	private void HandleHPPctChanged(float pct)
	{
		slider.value = pct;
	}
}