using System;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.ComputerVision;

public class TextureReaderWrapper : MonoBehaviour
{
    /// <summary>
    /// �擾����Texture�̃T�C�Y�́A�J�����摜�ɑ΂��銄��
    /// </summary>
    public float TextureSizeRatio = 1.0f;

    /// <summary>
    /// �J�����摜�̃f�[�^�Q
    /// </summary>
    private TextureReaderApi.ImageFormatType format;
    private int width;
    private int height;
    private IntPtr pixelBuffer;
    private int bufferSize = 0;
    public byte[] jpg;
    DateTime TodayNow;
    /// <summary>
    /// �J�����摜�擾�pAPI
    /// </summary>
    private TextureReader TextureReader = null;

    /// <summary>
    /// �J�����摜�̃T�C�Y�ɍ��킹��TextureReader���Z�b�g�������ǂ����̃t���O
    /// </summary>
    private bool setFrameSizeToTextureReader = false;


    public void Awake()
    {
        // �J�����摜�擾���ɌĂ΂��R�[���o�b�N�֐����`
        TextureReader = GetComponent<TextureReader>();
        TextureReader.OnImageAvailableCallback += OnImageAvailableCallbackFunc;
    }

    private void OnImageAvailableCallbackFunc(TextureReaderApi.ImageFormatType format, int width, int height, IntPtr pixelBuffer, int bufferSize)
    {
        /*
        this.format = format;
        this.width = width;
        this.height = height;
        this.pixelBuffer = pixelBuffer;
        this.bufferSize = bufferSize;
        */

        byte[] data = new byte[bufferSize];
        System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, data, 0, bufferSize);
       Texture2D _tex = new Texture2D(width, height, TextureFormat.RGBA32, false, false);
        _tex.LoadRawTextureData(data);
        _tex.Apply();
        jpg = _tex.EncodeToJPG();

        //NativeGallery.SaveImageToGallery(jpg, "DCIM", TodayNow.Year.ToString() + TodayNow.Month.ToString() + TodayNow.Day.ToString() + DateTime.Now.ToLongTimeString() + ".jpg");
    }
    public void aaa()
    {
        NativeGallery.SaveImageToGallery(jpg, "DCIM", TodayNow.Year.ToString() + TodayNow.Month.ToString() + TodayNow.Day.ToString() + DateTime.Now.ToLongTimeString() + ".jpg");
    }


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TodayNow = DateTime.Now;
        // TextureReader�ɃJ�����摜�̃T�C�Y���Z�b�g����B���s�͈�񂾂�
        if (!setFrameSizeToTextureReader)
        {
            using (var image = Frame.CameraImage.AcquireCameraImageBytes())
            {
                if (!image.IsAvailable)
                {
                    return;
                }

                TextureReader.ImageWidth = (int)(image.Width * TextureSizeRatio);
                TextureReader.ImageHeight = (int)(image.Height * TextureSizeRatio);
                TextureReader.Apply();

                setFrameSizeToTextureReader = true;
            }
        }
    }

    public Texture2D FrameTexture
    {
        get
        {
            if (bufferSize != 0)
            {
                // TextureReader���擾�����摜�f�[�^�̃|�C���^����f�[�^���擾
                byte[] data = new byte[bufferSize];
                System.Runtime.InteropServices.Marshal.Copy(pixelBuffer, data, 0, bufferSize);
                // ������270��]�Ɣ��]���Ă���̂ŕ␳����
                byte[] correctedData = Rotate90AndFlip(data, width, height, format == TextureReaderApi.ImageFormatType.ImageFormatGrayscale);

                
                
                // Texture2D���쐬 90�x��]�����Ă���̂�width/height�����ւ���
                Texture2D _tex = new Texture2D(height, width, TextureFormat.RGBA32, false, false);
                _tex.LoadRawTextureData(correctedData);
                _tex.Apply();

                return _tex;
                
            }
            else
            {
                return null;
            }
        }
    }


    private byte[] Rotate90AndFlip(byte[] img, int width, int height, bool isGrayscale)
    {
        int srcChannels = isGrayscale ? 1 : 4;
        int dstChannels = 4; //�o�͂͏��RGBA32�ɂ���
        byte[] newImg = new byte[width * height * dstChannels];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //img��index
                int p = (i * width + j) * srcChannels;

                //newImg�ɑ΂���index. 90�x��]�Ɣ��]�����Ă���
                int np = ((width - j - 1) * height + (height - i - 1)) * dstChannels;

                // �O���[�X�P�[���ł�RGB�ň�����悤�ɂ��Ă���
                if (isGrayscale)
                {
                    newImg[np] = img[p]; // R
                    newImg[np + 1] = img[p]; // G
                    newImg[np + 2] = img[p]; // B
                    newImg[np + 3] = 255; // A
                }
                else
                {
                    for (int c = 0; c < dstChannels; c++)
                    {
                        newImg[np + c] = img[p + c];
                    }
                }
            }
        }

        return newImg;
    }
}