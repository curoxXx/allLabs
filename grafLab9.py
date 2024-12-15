from PIL import Image, ImageFilter, ImageOps
import tkinter as tk
from tkinter import filedialog
import numpy as np

def low_pass_filter(image):
    return image.filter(ImageFilter.GaussianBlur(radius=10))

def high_pass_filter(image):
    return image.filter(ImageFilter.FIND_EDGES)

def process_image(image_path):
    image = Image.open(image_path)
    width, height = image.size
    mid_x = width // 2
    left_half = image.crop((0, 0, mid_x, height))
    right_half = image.crop((mid_x, 0, width, height))
    left_np = np.array(left_half)
    left_np[:, :, 0] = np.array(low_pass_filter(Image.fromarray(left_np[:, :, 0])))
    left_half_filtered = Image.fromarray(left_np)
    right_gray = ImageOps.grayscale(right_half)
    right_filtered = high_pass_filter(right_gray)
    combined_image = Image.new("RGB", (width, height))
    combined_image.paste(left_half_filtered, (0, 0))
    combined_image.paste(ImageOps.colorize(right_filtered, "black", "red"), (mid_x, 0))

    combined_image.save("filtered_image.png")
    print("Обработка завершена. Результат сохранён в filtered_image.png")

def main():
    root = tk.Tk()
    root.withdraw()
    file_path = filedialog.askopenfilename(title="Выберите изображение", filetypes=[("Image files", "*.png;*.jpg;*.jpeg")])
    if file_path:
        process_image(file_path)
    else:
        print("Файл не выбран.")

if __name__ == "__main__":
    main()
