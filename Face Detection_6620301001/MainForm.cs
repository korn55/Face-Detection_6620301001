using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace Face_Detection_6620301001
{
    public partial class MainForm : Form
    {
        private VideoCapture _camera;
        private VideoWriter _videoWriter;
        private CascadeClassifier _faceDetector;
        private bool _isRecording = false;
        public MainForm()
        {
            InitializeComponent();
            UpdateConnectionStatus("Disconnected");
            UpdateRecordStatus("Pause");

            // Load Haarcascade model
            try
            {
                string haarcascadePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascade_frontalface_default.xml");
                if (!File.Exists(haarcascadePath))
                {
                    throw new FileNotFoundException("Haarcascade model file not found.", haarcascadePath);
                }
                _faceDetector = new CascadeClassifier(haarcascadePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Haarcascade model: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (_camera == null)
                {
                    try
                    {
                        _camera = new VideoCapture(0); // Camera index 0
                        _camera.ImageGrabbed += ProcessFrame;
                        _camera.Start();

                        UpdateConnectionStatus("Connected");
                        Invoke(new Action(() => btnConnect.Text = "Disconnect"));
                    }
                    catch (Exception ex)
                    {
                        UpdateConnectionStatus("Disconnected");
                        MessageBox.Show($"Error connecting to camera: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    _camera.Dispose();
                    _camera = null;
                    UpdateConnectionStatus("Disconnected");
                    Invoke(new Action(() => btnConnect.Text = "Connect"));
                }
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnRecord_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (_camera == null)
                {
                    MessageBox.Show("Please connect the camera first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _isRecording = !_isRecording;
                UpdateRecordStatus(_isRecording ? "Play" : "Pause");
                Invoke(new Action(() => btnRecord.Text = _isRecording ? "Pause" : "Play"));

                if (_isRecording)
                {
                    string filePath = $"recorded_{DateTime.Now:yyyyMMdd_HHmmss}.avi";
                    int frameWidth = _camera.Width;
                    int frameHeight = _camera.Height;
                    _videoWriter = new VideoWriter(filePath, VideoWriter.Fourcc('M', 'J', 'P', 'G'), 30, new Size(frameWidth, frameHeight), true);
                    MessageBox.Show($"Recording started: {filePath}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _videoWriter?.Dispose();
                    _videoWriter = null;
                    MessageBox.Show("Recording stopped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
        }
        private void ProcessFrame(object sender, EventArgs e)
        {
            try
            {
                if (_camera != null && _camera.Ptr != IntPtr.Zero)
                {
                    var frame = new Mat();
                    _camera.Retrieve(frame);
                    var image = frame.ToImage<Bgr, byte>();

                    // Convert to grayscale and display
                    var grayImage = image.Convert<Gray, byte>();

                    // Detect faces
                    if (_faceDetector != null)
                    {
                        var faces = _faceDetector.DetectMultiScale(grayImage, 1.1, 10, Size.Empty);

                        foreach (var face in faces)
                        {
                            image.Draw(face, new Bgr(Color.Red), 2); // Draw rectangle around face
                        }

                        // Crop the first detected face and display in grayscale
                        if (faces.Length > 0)
                        {
                            var faceRect = faces[0];
                            var faceImage = grayImage.Copy(faceRect);
                            pictureBoxGray.Image = faceImage.ToBitmap(); // Show the first face
                        }
                    }

                    pictureBoxCamera.Image = image.ToBitmap();

                    if (_isRecording && _videoWriter != null)
                    {
                        _videoWriter.Write(frame);
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateConnectionStatus("Disconnected");
                MessageBox.Show($"Error processing frame: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateConnectionStatus(string status)
        {
            if (lblConnectionStatus.InvokeRequired)
            {
                // Ensure the handle is created before invoking
                if (lblConnectionStatus.IsHandleCreated)
                {
                    lblConnectionStatus.Invoke(new Action(() =>
                    {
                        lblConnectionStatus.Text = $"Camera Status: {status}";
                        lblConnectionStatus.ForeColor = status == "Connected" ? Color.Green : Color.Red;
                    }));
                }
            }
            else
            {
                lblConnectionStatus.Text = $"Camera Status: {status}";
                lblConnectionStatus.ForeColor = status == "Connected" ? Color.Green : Color.Red;
            }
        }
        private void UpdateRecordStatus(string status)
        {
            if (lblRecordStatus.InvokeRequired)
            {
                // Ensure the handle is created before invoking
                if (lblRecordStatus.IsHandleCreated)
                {
                    lblRecordStatus.Invoke(new Action(() =>
                    {
                        lblRecordStatus.Text = $"Recording: {status}";
                        lblRecordStatus.ForeColor = status == "Play" ? Color.Green : Color.Red;
                    }));
                }
            }
            else
            {
                lblRecordStatus.Text = $"Recording: {status}";
                lblRecordStatus.ForeColor = status == "Play" ? Color.Green : Color.Red;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_camera != null)
            {
                _camera.Dispose();
            }

            if (_videoWriter != null)
            {
                _videoWriter.Dispose();
            }
        }
    }
}
