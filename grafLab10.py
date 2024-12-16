from tkinter import filedialog, Tk, Label, Button, Entry, StringVar, OptionMenu
from PIL import Image, ImageTk
import os

image = None
file_path = ""

def load_image():
    global image, file_path
    file_path = filedialog.askopenfilename(title="Выберите изображение",
                                           filetypes=[("Image Files", "*.png;*.jpg;*.jpeg")])
    if file_path:
        image = Image.open(file_path)
        update_preview(image)
    else:
        print("Изображение не выбрано.")

def update_preview(img):
    img_resized = img.resize((300, 300))
    img_tk = ImageTk.PhotoImage(img_resized)
    image_label.config(image=img_tk)
    image_label.image = img_tk

def affine_transform():
    global image
    if image is None:
        print("\nСначала необходимо загрузить изображение.")
        return

    scale = float(scale_entry.get())
    angle = float(angle_entry.get())
    shear = float(shear_entry.get())
    method = interpolation_methods[method_var.get()]

    width, height = image.size
    new_size = (int(width * scale), int(height * scale))
    image_transformed = image.resize(new_size, method)

    image_transformed = image_transformed.rotate(angle, resample=method)

    shear_matrix = (1, shear / 100, 0, shear / 100, 1, 0)
    image_transformed = image_transformed.transform(new_size, Image.AFFINE, shear_matrix, resample=method)

    update_preview(image_transformed)

    output_path = os.path.join("results", "transformed_image.png")
    os.makedirs("results", exist_ok=True)
    image_transformed.save(output_path)
    print(f"\nРезультат сохранен в: {output_path}")

root = Tk()
root.title("Аффинные преобразования")

image_label = Label(root)
image_label.pack()

Label(root, text="Масштаб (х1.5):").pack()
scale_entry = Entry(root)
scale_entry.insert(0, "1.5")
scale_entry.pack()

Label(root, text="Угол поворота (градусы):").pack()
angle_entry = Entry(root)
angle_entry.insert(0, "30")
angle_entry.pack()

Label(root, text="Скос (сдвиг в %):").pack()
shear_entry = Entry(root)
shear_entry.insert(0, "10")
shear_entry.pack()

interpolation_methods = {
    "Nearest": Image.NEAREST,
    "Bilinear": Image.BILINEAR,
    "Bicubic": Image.BICUBIC
}
method_var = StringVar(root)
method_var.set("Bilinear")
Label(root, text="Метод интерполяции:").pack()
method_menu = OptionMenu(root, method_var, *interpolation_methods.keys())
method_menu.pack()

Button(root, text="Загрузить изображение", command=load_image).pack()
Button(root, text="Применить преобразования", command=affine_transform).pack()

root.mainloop()
