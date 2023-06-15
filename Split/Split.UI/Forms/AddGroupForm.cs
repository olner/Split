using Split.UI.Tools;
using Split.WebClient;

namespace Split.UI.Forms
{
    public partial class AddGroupForm : Form
    {
        private readonly SplitServiceApi client;

        public AddGroupForm(SplitServiceApi client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void AddGroupForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;

            addTb.Text = "Name";
            addTb.ForeColor = Color.Gray;

            InitializeComboBox();
        }

        private async void InitializeComboBox()
        {
            var rawFriends = await client.GetFriendsAsync(Data.Id);
            var friends = rawFriends.Response;
            if (friends == null || friends.Count == 0) return;

            foreach (var friend in friends)
            {
                int? id = 0;

                if (friend.UserId == Data.Id) id = friend.FriendId;
                else id = friend.UserId;

                var rawUser = await client.GetUserByIdAsync((int)id);
                var user = rawUser.Response;

                addTb.Items.Add(user.Login);
            }
        }

        private void addLinklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (addTb.Visible) addTb.Visible = false;
            else addTb.Visible = true;
        }

        private void addTb_Enter(object sender, EventArgs e)
        {
            addTb.Text = null;
            addTb.ForeColor = Color.Black;
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
            try
            {
                if (nameTb.Text.Length == 0) return;

                var text = nameTb.Text;
                if (descriptionRtb.Text.Length != 0)
                {
                    text = descriptionRtb.Text;
                }

                var result = await client.AddGroupAsync(nameTb.Text, Data.Id, text);
                var group = result.Response;

                await client.AddUserToGroupAsync(group.Id, Data.Id);
                foreach (var item in membersLb.Items)
                {
                    var rawResult = await client.GetUserByLoginAsync(item.ToString());
                    var user = rawResult.Response;
                    await client.AddUserToGroupAsync(group.Id, user.Id);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            this.Close();
        }


        private async void addTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                foreach (string item in membersLb.Items)
                {
                    if (item == addTb.Text) return;
                }

                var result = await client.GetUserByLoginAsync(addTb.Text);
                var user = result.Response;
                if (user == null) return;

                membersLb.Items.Add(addTb.Text);
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (membersLb.SelectedItem == null) return;

            if (e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
                membersLb.Items.Remove(membersLb.SelectedItem);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e) => this.Close();
    }
}
