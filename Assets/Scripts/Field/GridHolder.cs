using System;
using UnityEngine;

namespace Field
{
    public class GridHolder: MonoBehaviour
    {
        [SerializeField] private int m_GridWidth;
        [SerializeField] private int m_GridHeight;
        [SerializeField] private float m_NodeSize;
        
        private Grid m_Grid;
        private Camera m_Camera;
        private Vector3 m_Offset;

        private void Awake()
        {
            m_Grid = new Grid(m_GridWidth, m_GridHeight);
            m_Camera = Camera.main;

            transform.localScale = new Vector3(m_GridWidth * m_NodeSize*0.1f, 1f, m_GridHeight * m_NodeSize*0.1f);
            
        }

        private void Update()
        {
            if (m_Grid == null)
            {
                return;
            }

            Vector3 mousePosition = Input.mousePosition;

            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform != transform)
                {
                    return;
                }

                Debug.Log("hit!");
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(m_Offset, 4f);
        }
    }
}