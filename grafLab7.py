import tkinter as tk
from tkinter import filedialog
from PIL import Image, ImageDraw, ImageTk

class ImageProcessorApp:
    def __init__(self, master):
        self.master = master
        self.master.title("Обработка изображений")
        self.master.geometry("1000x520")
        self.original_image = None
        self.new_image = None
        self.canvas1_image = None
        self.canvas2_image = None
        self.width_var = tk.StringVar(value="300")
        self.height_var = tk.StringVar(value="300")
        self.x1_var = tk.StringVar(value="100")
        self.y1_var = tk.StringVar(value="150")
        self.radius_var = tk.StringVar(value="50")
        self.x2_var = tk.StringVar(value="200")
        self.y2_var = tk.StringVar(value="150")
        self.create_interface()

    def create_interface(self):
        tk.Label(self.master, text="Ширина").grid(row=0, column=0)
        tk.Entry(self.master, textvariable=self.width_var).grid(row=0, column=1)

        tk.Label(self.master, text="Высота").grid(row=0, column=2)
        tk.Entry(self.master, textvariable=self.height_var).grid(row=0, column=3)

        tk.Label(self.master, text="Центр из загружаемого изображения x1").grid(row=1, column=0)
        tk.Entry(self.master, textvariable=self.x1_var).grid(row=1, column=1)

        tk.Label(self.master, text="Центр из загружаемого изображения y1").grid(row=1, column=2)
        tk.Entry(self.master, textvariable=self.y1_var).grid(row=1, column=3)

        tk.Label(self.master, text="Радиус").grid(row=1, column=4)
        tk.Entry(self.master, textvariable=self.radius_var).grid(row=1, column=5)

        tk.Label(self.master, text="x2").grid(row=2, column=0)
        tk.Entry(self.master, textvariable=self.x2_var).grid(row=2, column=1)

        tk.Label(self.master, text="y2").grid(row=2, column=2)
        tk.Entry(self.master, textvariable=self.y2_var).grid(row=2, column=3)

        tk.Button(self.master, text="Создать", command=self.create_image).grid(row=3, column=0)
        tk.Button(self.master, text="Открыть", command=self.load_image).grid(row=3, column=1)
        tk.Button(self.master, text="Перенести", command=self.copy_circle).grid(row=3, column=2)
        tk.Button(self.master, text="Координаты", command=self.draw_axes).grid(row=3, column=3)
        tk.Button(self.master, text="x^2", command=self.draw_graph).grid(row=3, column=4)
        tk.Button(self.master, text="Сохранить", command=self.save_image).grid(row=3, column=5)

        self.canvas1 = tk.Canvas(self.master, width=400, height=400, bg="gray")
        self.canvas1.grid(row=4, column=0, columnspan=3)

        self.canvas2 = tk.Canvas(self.master, width=400, height=400, bg="gray")
        self.canvas2.grid(row=4, column=3, columnspan=3)

    def create_image(self):
        width = int(self.width_var.get())
        height = int(self.height_var.get())
        self.new_image = Image.new("RGB", (width, height), "white")
        self.display_image(self.new_image, self.canvas2)

    def load_image(self):
        filepath = filedialog.askopenfilename(filetypes=[("Image Files", "*.png;*.jpg;*.jpeg")])
        if filepath:
            self.original_image = Image.open(filepath).convert("RGB")
            self.original_image = self.original_image.resize((400, 400))
            self.display_image(self.original_image, self.canvas1)

    def copy_circle(self):
        if not self.original_image or not self.new_image:
            tk.messagebox.showerror("Ошибка", "Необходимо загрузить исходное и создать новое изображение!")
            return

        x1, y1 = int(self.x1_var.get()), int(self.y1_var.get())
        x2, y2 = int(self.x2_var.get()), int(self.y2_var.get())
        radius = int(self.radius_var.get())

        draw = ImageDraw.Draw(self.new_image)
        for px in range(self.original_image.width):
            for py in range(self.original_image.height):
                if (px - x1)**2 + (py - y1)**2 <= radius**2:
                    color = self.original_image.getpixel((px, py))
                    try:
                        self.new_image.putpixel((x2 + px - x1, y2 + py - y1), color)
                    except IndexError:
                        pass

        self.display_image(self.new_image, self.canvas2)

    def draw_axes(self):
        if not self.new_image:
            tk.messagebox.showerror("Ошибка", "Сначала создайте изображение!")
            return

        draw = ImageDraw.Draw(self.new_image)
        width, height = self.new_image.size
        draw.line((0, height // 2, width, height // 2), fill="black")
        draw.line((width // 2, 0, width // 2, height), fill="black")
        self.display_image(self.new_image, self.canvas2)

    def draw_graph(self):
        if not self.new_image:
            tk.messagebox.showerror("Ошибка", "Сначала создайте изображение!")
            return
        draw = ImageDraw.Draw(self.new_image)
        width, height = self.new_image.size
        center_x, center_y = width // 2, height // 2
        scale = 0.05
        for x in range(-center_x, center_x):
            y = scale * (x**2)
            screen_x = center_x + x
            screen_y = center_y - int(y)
            if 0 <= screen_x < width and 0 <= screen_y < height:
                draw.point((screen_x, screen_y), fill="blue")
        self.display_image(self.new_image, self.canvas2)

    def save_image(self):
        filepath = filedialog.asksaveasfilename(defaultextension=".png", filetypes=[("PNG Files", "*.png")])
        if filepath:
            self.new_image.save(filepath)

    def display_image(self, image, canvas):
        tk_image = ImageTk.PhotoImage(image.resize((400, 400)))
        canvas.create_image(0, 0, anchor=tk.NW, image=tk_image)
        canvas.image = tk_image

if __name__ == "__main__":
    root = tk.Tk()
    app = ImageProcessorApp(root)
    root.mainloop()
