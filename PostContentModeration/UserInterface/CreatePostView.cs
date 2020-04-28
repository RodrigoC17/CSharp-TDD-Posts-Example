﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace UserInterface
{
    public delegate void HandleCreation();
    public partial class CreatePostView : UserControl
    {
        private PostsRepository posts;
        private event HandleCreation PostCreatedEvent;

        public CreatePostView(PostsRepository repository)
        {
            InitializeComponent();
            posts = repository;
        }

        public void AddListener(HandleCreation del) {
            PostCreatedEvent += del;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            try {
                string title = txtTitle.Text;
                string body = txtBody.Text;
                DateTime pubDate = pubDatePicker.Value;

                Post newPost = new Post(title, body, pubDate);
                posts.Add(newPost);
                PostCreatedEvent();
            }
            catch (InvalidPostException ex) {
                lbError.Text = ex.Message;
            }
        }

    }
}
