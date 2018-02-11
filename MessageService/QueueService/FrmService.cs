﻿using System;
using System.Windows.Forms;

namespace QueueService
{
    public partial class FrmService : Form
    {

        Service service;
        public FrmService(Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FrmService_Load(object sender, EventArgs e)
        {
            this.service.clientListChanged = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.service.clientListChanged)
                return;
            this.listView1.Items.Clear();
            foreach (var client in service.clientList.Dictionary.Values)
            {
                var item = this.listView1.Items.Add(client.ID.ToString());
                item.SubItems.Add(client.IP);
                item.SubItems.Add(client.Name);
                item.SubItems.Add(client.Type);
                item.SubItems.Add(client.ConnTime);
            }
            this.service.clientListChanged = false;
        }
    }
}