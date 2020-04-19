using System.ComponentModel;

namespace Client
{
    partial class InviteWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.AcceptInvationButton = new System.Windows.Forms.Button();
            this.RejectInvitationButton = new System.Windows.Forms.Button();
            this.nameOfTheChat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "You are receiving an invitation from ";
            // 
            // AcceptInvationButton
            // 
            this.AcceptInvationButton.Location = new System.Drawing.Point(65, 160);
            this.AcceptInvationButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AcceptInvationButton.Name = "AcceptInvationButton";
            this.AcceptInvationButton.Size = new System.Drawing.Size(134, 37);
            this.AcceptInvationButton.TabIndex = 1;
            this.AcceptInvationButton.Text = "Accept";
            this.AcceptInvationButton.UseVisualStyleBackColor = true;
            this.AcceptInvationButton.Click += new System.EventHandler(this.AcceptInvationButton_Click);
            // 
            // RejectInvitationButton
            // 
            this.RejectInvitationButton.Location = new System.Drawing.Point(241, 160);
            this.RejectInvitationButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RejectInvitationButton.Name = "RejectInvitationButton";
            this.RejectInvitationButton.Size = new System.Drawing.Size(134, 37);
            this.RejectInvitationButton.TabIndex = 2;
            this.RejectInvitationButton.Text = "Reject";
            this.RejectInvitationButton.UseVisualStyleBackColor = true;
            this.RejectInvitationButton.Click += new System.EventHandler(this.RejectInvitationButton_Click);
            // 
            // nameOfTheChat
            // 
            this.nameOfTheChat.AutoSize = true;
            this.nameOfTheChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameOfTheChat.Location = new System.Drawing.Point(114, 84);
            this.nameOfTheChat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameOfTheChat.Name = "nameOfTheChat";
            this.nameOfTheChat.Size = new System.Drawing.Size(91, 18);
            this.nameOfTheChat.TabIndex = 3;
            this.nameOfTheChat.Text = "Chat Name: ";
            // 
            // InviteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(437, 251);
            this.Controls.Add(this.nameOfTheChat);
            this.Controls.Add(this.RejectInvitationButton);
            this.Controls.Add(this.AcceptInvationButton);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "InviteWindow";
            this.Text = "Invitation for Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InviteWindow_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AcceptInvationButton;
        private System.Windows.Forms.Button RejectInvitationButton;
        private System.Windows.Forms.Label nameOfTheChat;
    }
}