using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField]
    private SparkPanel sparkPanel;
    public SparkPanel SparkPanel => sparkPanel;
    [SerializeField]
    private PulsePanel pulsePanel;
    public PulsePanel PulsePanel => pulsePanel;
    [SerializeField]
    private WavePanel wavePanel;
    public WavePanel WavePanel => wavePanel;
    [SerializeField]
    private BoltPanel boltPanel;
    public BoltPanel BoltPanel => boltPanel;
    // Start is called before the first frame update
    void Start()
    {
        ActiveSparkPanel(true);
        ActivePulsePanel(false);
        ActiveWavePanel(false);
        ActiveBoltPanel(false);
    }

    public void ActiveSparkPanel(bool active)
    {
        sparkPanel.gameObject.SetActive(active);
    }
    public void ActivePulsePanel(bool active)
    {
        pulsePanel.gameObject.SetActive(active);
    }
    public void ActiveWavePanel(bool active)
    {
        wavePanel.gameObject.SetActive(active);
    }
    public void ActiveBoltPanel(bool active)
    {
        BoltPanel.gameObject.SetActive(active);
    }
}
