using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using UnidenDAL.AssyLine;
using UnidenDAL;
using UnidenDTO;
using UnidenDAL.Assy.Setup;
using UnidenDAL.Jig;
using UnidenDAL.SysControl.Setup;
using UnidenDAL.Assy;
using System.Diagnostics;
using ClosedXML;
using UnidenDAL.SysControl;
using ListViewItem = System.Windows.Forms.ListViewItem;
using System.Data.SqlClient;

namespace SMTPRORAM.Assy.Setup
{
    public partial class frmSetupProcessLine : Form
    {
        bool AddFlag = false;
        private long Id = 0;
        private List<SYS_UserButtonFunction> lstUBFunction;
        public frmSetupProcessLine()
        {
            InitializeComponent();
        }
        private void loadListNonScanQR()
        {
            
            this.listViewNonScanQR.Columns.Add("Process Name", 95, HorizontalAlignment.Left);
            this.listViewNonScanQR.Columns.Add("Order Number", 95, HorizontalAlignment.Left);
            this.listViewNonScanQR.Columns.Add("ID", 5, HorizontalAlignment.Left);
			this.listViewNonScanQR.Columns.Add("GroupProcess", 5, HorizontalAlignment.Left);
			listViewNonScanQR.View = System.Windows.Forms.View.Details;
            listViewNonScanQR.GridLines = true;
        }
        private void loadListScanQR()
        {
           
            this.listViewScanQR.Columns.Add("Process Name", 95, HorizontalAlignment.Left);
            this.listViewScanQR.Columns.Add("Order Number", 95, HorizontalAlignment.Left);
            this.listViewScanQR.Columns.Add("ID", 5, HorizontalAlignment.Left);
			this.listViewScanQR.Columns.Add("GroupProcess", 5, HorizontalAlignment.Left);
			listViewScanQR.View = System.Windows.Forms.View.Details;
            listViewScanQR.GridLines = true;
        }

        private void frmSetupProcessLine_Load(object sender, EventArgs e)
        {
            showHideControll(true);
            _enable(false);
            loadListNonScanQR();
            loadListScanQR();
            loadLotforCombobox();
            loadGroupProcessFofCombobox();

			numericUpDown1.Enabled=false;
            numericUpDown2.Enabled=false;

            lstUBFunction = SYSButtonFunctionDAL.Instance.getUBFuntion(Program.UserId);
            var lst = CommonDAL.Instance.AllSubControls(this).ToList();
            CommonDAL.Instance.CheckButtonEnable(lst, lstUBFunction);
        }
        void _enable(bool t)
        {
            cbLot.Enabled = t;
            txtProcessName.Enabled = t;
            chkStatus.Enabled = t;           
        }

        void ResetControll()
        {
            cbLot.Text = "";
            txtProcessName.Text = "";
            chkStatus.Checked = false;
        }
        void showHideControll(bool t)
        {
            iconbtnAdd.Visible = t;
            iconbtnEdit.Visible = t;
            iconbtnDelete.Visible = t;
            iconbtnCancel.Visible = !t;
            iconbtnSave.Visible = !t;
        }
        
        private void Search(string search)
        {
            if (search.Equals(""))
            {
                MessageBox.Show("Hãy nhập điều kiện tìm kiếm vào đây !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSearch.Focus();
                return;
            }
            else
            {
                CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, LINEPROCESS_DAL.Instance.getListLineProcessByLot(search));
            }
        }

        private void iconbtnAdd_Click(object sender, EventArgs e)
        {
            AddFlag = true;
            showHideControll(false);
            _enable(true);
            ResetControll();
            cbLot.Focus();
        }

        private void iconbtnEdit_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            _enable(true);
            cbLot.Enabled = false;
            showHideControll(false);
        }
        private void loadLotforCombobox()
        {
            DataTable dtLot = new DataTable();
            dtLot = MODELLOTINFO_DAL.Instance.getLotForSetupProcess();
            DataRow dataRow = dtLot.NewRow();
            dataRow["Lot"] = "--Select--";
            dtLot.Rows.InsertAt(dataRow, 0);
            
            cbLot.DataSource = dtLot;
            cbLot.DisplayMember = "Lot";
            cbLot.ValueMember = "Lot";
        }
		private void loadGroupProcessFofCombobox()
		{
			var lstGroupProcess = new List<UV_GROUP_PROCESS>();
            lstGroupProcess = GROUP_PROCESS_DAL.Instance.getListGroupProcess();
            var groupPrcess = new UV_GROUP_PROCESS();
            groupPrcess.GroupId = 0;
            groupPrcess.GroupName = "--Select--";

            lstGroupProcess.Add(groupPrcess);

			cbgroupProcess.DataSource = lstGroupProcess.OrderBy(p=>p.GroupId).ToList();
			cbgroupProcess.DisplayMember = "GroupName";
			cbgroupProcess.ValueMember = "GroupName";
		}
		private void iconbtnDelete_Click(object sender, EventArgs e)
        {
            if (Id>0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var delProcess = new UV_LINEPROCESS();
                    delProcess.ProcessId= Id;
                    delProcess.DeleteSatus = true;
                    delProcess.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();
                    delProcess.UpdatedBy = Program.UserId;
                    string message;
                    message=LINEPROCESS_DAL.Instance.Delete(delProcess);
                    if (message=="")
                    {
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, LINEPROCESS_DAL.Instance.getListLineProcessByLot(cbLot.Text));
                showHideControll(true);
                ResetControll();
                _enable(false);
            }
        }
        private bool IsDataOK()
        {
            if (cbLot.Text.Trim().Equals("")|| cbLot.Text.Trim().Equals("--Select--"))
            {
                MessageBox.Show("Lot Không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLot.Focus();
                return false;
            }
            if (cbgroupProcess.Text.Trim().Equals("") || cbgroupProcess.Text.Trim().Equals("--Select--"))
            {
				MessageBox.Show("Group Không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cbgroupProcess.Focus();
				return false;
			}
            if (txtProcessName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Tên công đoạn không được để trống !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProcessName.Focus();
                return false;
            }            
            return true;
        }
        private void iconbtnSave_Click(object sender, EventArgs e)
        {
            if (IsDataOK() == true)
            {   
                string message = "";
                if (AddFlag)
                {
                    if (chkAuto.Checked)
                    {
                        if (int.Parse(numericUpDown1.Value.ToString())>int.Parse(numericUpDown2.Value.ToString()))
                        {
                            MessageBox.Show("Từ số phải nhỏ hơn tới số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            numericUpDown2.Focus();
                            return;
                        }
                        else
                        {
                            var lstProcess= new List<UV_LINEPROCESS>();
                            DateTime date= CommonDAL.Instance.getSqlServerDatetime();
                            for (int i = int.Parse(numericUpDown1.Value.ToString());
                                i <= int.Parse(numericUpDown2.Value.ToString()); i++)
                            {
                                var lineProcess = new UV_LINEPROCESS();
                                lineProcess.Lot = cbLot.Text;
                                lineProcess.GroupProcess=cbgroupProcess.Text;
                                lineProcess.ProcessName = txtProcessName.Text+i.ToString("00");
                                lineProcess.Status = chkStatus.Checked;
                                lineProcess.Completed = false;
                                lineProcess.DeleteSatus= false;
                                lineProcess.CreatedBy = Program.UserId;
                                lineProcess.CreatedDate = date;
                                var checkExist = new UV_LINEPROCESS();
                                checkExist=LINEPROCESS_DAL.Instance.checkExitsProcessName(cbLot.Text, lineProcess.ProcessName);
                                if (checkExist==null)
                                {
                                    lstProcess.Add(lineProcess);
                                }
                                else
                                {
                                    MessageBox.Show("Đã tôn Tại process Name: " +  checkExist.ProcessName,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    return;                                    
                                }
                                
                            }
                            message = LINEPROCESS_DAL.Instance.AddList(lstProcess);
                            if (message == "")
                            {
                                MessageBox.Show("Save OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReloadData(cbLot.Text);
                            }
                            else
                            {
                                MessageBox.Show("Đã có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        var lineProcess = new UV_LINEPROCESS();
                        lineProcess.Lot = cbLot.Text;
                        lineProcess.GroupProcess=cbgroupProcess.Text;
                        lineProcess.ProcessName = txtProcessName.Text;
                        lineProcess.Status = chkStatus.Checked;
                        lineProcess.Completed = false;
                        lineProcess.DeleteSatus= false;
                        lineProcess.CreatedBy = Program.UserId;
                        lineProcess.CreatedDate = CommonDAL.Instance.getSqlServerDatetime();
                        var checkExist = new UV_LINEPROCESS();
                        checkExist = LINEPROCESS_DAL.Instance.checkExitsProcessName(cbLot.Text, lineProcess.ProcessName);
                        if (checkExist != null)
                        {
                            MessageBox.Show("Đã tôn Tại process Name: " + checkExist.ProcessName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            message = LINEPROCESS_DAL.Instance.Add(lineProcess);
                            if (message == "")
                            {
                                MessageBox.Show("Save OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReloadData(cbLot.Text);
                            }
                            else
                            {
                                MessageBox.Show("Đã có lỗi xảy ra: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }               
                
                }
                else
                {
                    if (Id>0)
                    {
                        var lineProcess = new UV_LINEPROCESS();
                        lineProcess.Lot = cbLot.Text;
                        lineProcess.GroupProcess=cbgroupProcess.Text;
                        lineProcess.ProcessName = txtProcessName.Text;
                        lineProcess.ProcessId = Id;
                        lineProcess.UpdatedBy = Program.UserId;
                        lineProcess.Status=chkStatus.Checked;
                        lineProcess.UpdatedDate = CommonDAL.Instance.getSqlServerDatetime();                       
                        message = LINEPROCESS_DAL.Instance.Update(lineProcess);
                        if (message == "")
                        {
                            MessageBox.Show("Sửa  OK", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReloadData(cbLot.Text);                            
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi sửa bản ghi: " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                AddFlag = false;               
                showHideControll(true);
                ResetControll();
                _enable(false);
            }
        }

        private void iconbtnCancel_Click(object sender, EventArgs e)
        {
            AddFlag = false;
            showHideControll(true);
            _enable(false);
        }

        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgView.RowCount > 0)
            {
                DataGridViewRow row = dgView.SelectedCells[0].OwningRow;
                Id= long.Parse(row.Cells["ProcessId"].Value.ToString());
                cbgroupProcess.Text=row.Cells["GroupProcess"].Value.ToString();
				cbLot.Text = row.Cells["LOT"].Value.ToString();
                txtProcessName.Text = row.Cells["ProcessName"].Value.ToString();
                chkStatus.Checked =bool.Parse( row.Cells["Status"].Value.ToString());               
            }
        }

        private void iconbtnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter==e.KeyCode)
            {
                Search(txtSearch.Text);
            }
        }

        private void cbLot_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonDAL.Instance.DropDownCombo(sender,e);
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuto.Checked)
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
            else
            {
                numericUpDown1.Enabled=false;
                numericUpDown2.Enabled=false;
            }
        }

        private void iconbtnReset_Click(object sender, EventArgs e)
        {
            if (cbLot.Text.Equals("")|| cbLot.Text.Equals("[None]"))
            {
                MessageBox.Show("Chọn LOT cần reset", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLot.Focus();
                return;
            }
            else
            {
                var listProcess=LINEPROCESS_DAL.Instance.getListResetCompleteByProcessId(cbLot.Text);
                if (listProcess.Count>0)
                {
                    foreach (var item in listProcess)
                    {
                        string message=LINEPROCESS_DAL.Instance.ResetIsComplete(item.ProcessId);
                        if (message!="")
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi chuyển trạng thái complete của lot", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                    MessageBox.Show("Reset đã xong !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, LINEPROCESS_DAL.Instance.getListLineProcessByLot(cbLot.Text));
                }
            }
        }
        private void LoadListViewNonScanQR(List<ListBoxView> lst)
        {
            listViewNonScanQR.Items.Clear();            
            foreach (var items in lst)
            {
                System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem
                (new string[] 
                    {   
                        items.processName, 
                        items.orderProcess.ToString() ,
                        items.processID.ToString(),
                        items.groupProcess.ToString() 
                        
                    });
                listViewNonScanQR.Items.Add(item);
            }
        }
        private void LoadListViewScanQR(List<ListBoxView> lst)
        {
            listViewScanQR.Items.Clear();
            foreach (var items in lst)
            {
                System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem
                    (new string[] 
                    {   
                        items.processName, 
                        items.orderProcess.ToString() ,
                        items.processID.ToString(),
                        items.groupProcess.ToString() 
                    });
                listViewScanQR.Items.Add(item);
            }
        }

        private void LoaddgViewAgain()
        {
            var dt = new DataTable();
            dt = LINEPROCESS_DAL.Instance.getListLineProcessByLot(cbLot.Text);
            CommonDAL.Instance.ShowDataGridViewWithDataTable(dgView, dt);
        }

        private void ReloadData(string Lot)
        {
            var lstNonScanQRByLot = new List<ListBoxView>();
            var lstScanQRByLot = new List<ListBoxView>();
            lstNonScanQRByLot = LINEPROCESS_DAL.Instance.getProcessNonScanQRByLot(Lot);
            lstScanQRByLot = LINEPROCESS_DAL.Instance.getProcessScanQRByLot(Lot);
            LoadListViewNonScanQR(lstNonScanQRByLot);
            LoadListViewScanQR(lstScanQRByLot);
            LoaddgViewAgain();
        }
        private void cbLot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Hiển thị danh sách process khi chọn LOT
            // Nếu LOT chưa được tạo thì sẽ không có dữ liệu
            ReloadData(cbLot.Text);
        }

        private void listViewNonScanQR_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void listViewScanQR_DragEnter(object sender, DragEventArgs e)
        {
            // Check that the dragged item is a ListViewItem
            if (e.Data.GetDataPresent(typeof(System.Windows.Forms.ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void listViewScanQR_DragDrop(object sender, DragEventArgs e)
        {
            // Get the drop location and the dropped item
            Point drop = listViewScanQR.PointToClient(new Point(e.X, e.Y));
            ListViewItem item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

            // Insert the item at the drop location
            ListViewItem target = listViewScanQR.GetItemAt(drop.X, drop.Y);
            int index = target != null ? target.Index : listViewScanQR.Items.Count;
            listViewScanQR.Items.Insert(index, (ListViewItem)item.Clone());
            listViewScanQR.Items.Remove(item);
        }

        private void listViewNonScanQR_DragEnter(object sender, DragEventArgs e)
        {
            // Check that the dragged item is a ListViewItem
            if (e.Data.GetDataPresent(typeof(System.Windows.Forms.ListViewItem)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void listViewNonScanQR_DragDrop(object sender, DragEventArgs e)
        {
            Point drop;
            drop = listViewNonScanQR.PointToClient(new Point(e.X, e.Y));
            ListViewItem item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));

            // Insert the item at the drop location
            ListViewItem target = listViewNonScanQR.GetItemAt(drop.X, drop.Y);
            int index = target != null ? target.Index : listViewNonScanQR.Items.Count;
            listViewNonScanQR.Items.Insert(index, (ListViewItem)item.Clone());
            listViewNonScanQR.Items.Remove(item);
        }

        private void iconbtnToRight_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewNonScanQR.SelectedItems)
            {
                listViewScanQR.Items.Add((ListViewItem)item.Clone());
                listViewNonScanQR.Items.Remove(item);
            }
        }

        private void iconbtnToLeft_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewScanQR.SelectedItems)
            {
                listViewNonScanQR.Items.Add((ListViewItem)item.Clone());
                listViewScanQR.Items.Remove(item);
            }
        }

        private void iconbtnNonScanQRUp_Click(object sender, EventArgs e)
        {
            // Check that there is a selected item and that it is not the first item
            if (listViewNonScanQR.SelectedItems.Count > 0 && listViewNonScanQR.SelectedItems[0].Index > 0)
            {
                int index = listViewNonScanQR.SelectedItems[0].Index;
                ListViewItem item = listViewNonScanQR.SelectedItems[0];
                listViewNonScanQR.Items.Remove(item);
                listViewNonScanQR.Items.Insert(index - 1, item);
                listViewNonScanQR.Items[index - 1].Selected = true;
            }
        }

        private void iconbtnNonScanQRDown_Click(object sender, EventArgs e)
        {
            // Check that there is a selected item and that it is not the last item
            if (listViewNonScanQR.SelectedItems.Count > 0 && listViewNonScanQR.SelectedItems[0].Index < listViewNonScanQR.Items.Count - 1)
            {
                int index = listViewNonScanQR.SelectedItems[0].Index;
                ListViewItem item = listViewNonScanQR.SelectedItems[0];
                listViewNonScanQR.Items.Remove(item);
                listViewNonScanQR.Items.Insert(index + 1, item);
                listViewNonScanQR.Items[index + 1].Selected = true;
            }
        }

        private void iconbtnScanQRUp_Click(object sender, EventArgs e)
        {

            // Check that there is a selected item and that it is not the first item
            if (listViewScanQR.SelectedItems.Count > 0 && listViewScanQR.SelectedItems[0].Index > 0)
            {
                int index = listViewScanQR.SelectedItems[0].Index;
                ListViewItem item = listViewScanQR.SelectedItems[0];
                listViewScanQR.Items.Remove(item);
                listViewScanQR.Items.Insert(index - 1, item);
                listViewScanQR.Items[index - 1].Selected = true;
            }
        }

        private void iconbtnScanQRDown_Click(object sender, EventArgs e)
        {
            // Check that there is a selected item and that it is not the last item
            if (listViewScanQR.SelectedItems.Count > 0 && listViewScanQR.SelectedItems[0].Index < listViewScanQR.Items.Count - 1)
            {
                int index = listViewScanQR.SelectedItems[0].Index;
                ListViewItem item = listViewScanQR.SelectedItems[0];
                listViewScanQR.Items.Remove(item);
                listViewScanQR.Items.Insert(index + 1, item);
                listViewScanQR.Items[index + 1].Selected = true;
            }
        }

        private void iconSaveToDB_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từng ListView lưu vào DB theo thứ tự và update status
            // status=1 (true) có scan qr code
            // status=0 (false) không scan qr code
            // updatedBy, updatedDate
            string updatedBy = null;
            DateTime updatedDate = CommonDAL.Instance.getSqlServerDatetime();
            CommonDAL.Instance.BeginTransaction();
            int scanQRcount = 0;
            string message = "";

			// Lấy danh sách các giá trị duy nhất của cột "processgroup"
			List<string> uniqueGroups0 = new List<string>();
			foreach (ListViewItem item in listViewScanQR.Items)
			{
				string group = item.SubItems[3].Text;
				if (!uniqueGroups0.Contains(group))
				{
					uniqueGroups0.Add(group);
				}
			}

			// Thiết lập số thứ tự cho từng nhóm
			foreach (string group in uniqueGroups0)
			{
				int orderNumber1 = 0;
				foreach (ListViewItem item in listViewScanQR.Items)
				{
					if (item.SubItems[3].Text == group)
					{
						// Thiết lập số thứ tự cho item trong cột "order number"
						message = LINEPROCESS_DAL.Instance.UpdateOrder(long.Parse(item.SubItems[2].Text), item.SubItems[3].Text, orderNumber1, true, Program.UserId, updatedDate);
						if (message != "")
						{
							break;
						}
						orderNumber1++;
					}
				}
			}

			// Lấy danh sách các giá trị duy nhất của cột "processgroup"
			List<string> uniqueGroups1 = new List<string>();
			foreach (ListViewItem item in listViewNonScanQR.Items)
			{
				string group = item.SubItems[3].Text;
				if (!uniqueGroups1.Contains(group))
				{
					uniqueGroups1.Add(group);
				}
			}

			// Thiết lập số thứ tự cho từng nhóm
			foreach (string group in uniqueGroups1)
			{
				int orderNumber2 = 0;
				foreach (ListViewItem item in listViewNonScanQR.Items)
				{
					if (item.SubItems[3].Text == group)
					{
						// Thiết lập số thứ tự cho item trong cột "order number"
						message = LINEPROCESS_DAL.Instance.UpdateOrder(long.Parse(item.SubItems[2].Text), item.SubItems[3].Text, orderNumber2, false, Program.UserId, updatedDate);
						if (message != "")
						{
							break;
						}
						orderNumber2++;
					}
				}
			}



			//foreach (ListViewItem item in listViewScanQR.Items)
			//         {

			//             message = LINEPROCESS_DAL.Instance.UpdateOrder(long.Parse(item.SubItems[2].Text), item.SubItems[3].Text ,scanQRcount,true,updatedBy, updatedDate);
			//             scanQRcount++;
			//             if (message!="")
			//             {
			//                 break;
			//             }
			//             //SqlCommand insertCommand = new SqlCommand("INSERT INTO List1 (Column1, Column2) VALUES (@Column1, @Column2)", conn);
			//             //insertCommand.Parameters.AddWithValue("@Column1", item.SubItems[0].Text);
			//             //insertCommand.Parameters.AddWithValue("@Column2", item.SubItems[1].Text);
			//             //insertCommand.ExecuteNonQuery();
			//         }
			//         int noScanQRcount = 0;
			//         foreach (ListViewItem item in listViewNonScanQR.Items)
			//         {
			//             message=LINEPROCESS_DAL.Instance.UpdateOrder(long.Parse(item.SubItems[2].Text), item.SubItems[3].Text, noScanQRcount,false,updatedBy, updatedDate);
			//             noScanQRcount++;
			//             if (message != "")
			//             {
			//                 break;
			//             }
			//             //SqlCommand insertCommand = new SqlCommand("INSERT INTO List1 (Column1, Column2) VALUES (@Column1, @Column2)", conn);
			//             //insertCommand.Parameters.AddWithValue("@Column1", item.SubItems[0].Text);
			//             //insertCommand.Parameters.AddWithValue("@Column2", item.SubItems[1].Text);
			//             //insertCommand.ExecuteNonQuery();
			//         }
			if (message!="") 
            {
                CommonDAL.Instance.RollbackTransaction();
                MessageBox.Show("Đã có lỗi khi lưu lại dữ liệu: "+ message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                CommonDAL.Instance.CommitTransaction();
                ReloadData(cbLot.Text);
                MessageBox.Show("Save Ok", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
    }
}
