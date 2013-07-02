function draw() {
    var canvas = document.getElementById('canvas');
    if (canvas.getContext) {
        var context = canvas.getContext('2d');

        context.clearRect(0, 0, 700, 700);

        //Lewy górny róg

        context.fillStyle = "#E74C3C";
        context.fillRect(0, 0, 30, 90);

        context.fillStyle = "#C0392B";
        context.fillRect(30, 30, 10, 60);

        context.fillStyle = "#E74C3C";
        context.fillRect(0, 0, 90, 30);

        context.fillStyle = "#C0392B";
        context.fillRect(30, 30, 60, 10);

        //Prawy górny

        context.fillStyle = "#E74C3C";
        context.fillRect(670, 0, 30, 90);

        context.fillStyle = "#C0392B";
        context.fillRect(660, 30, 10, 60);

        context.fillStyle = "#E74C3C";
        context.fillRect(610, 0, 60, 30);

        context.fillStyle = "#C0392B";
        context.fillRect(610, 30, 60, 10);

        //Lewy dolny

        context.fillStyle = "#E74C3C";
        context.fillRect(0, 610, 30, 90);

        context.fillStyle = "#C0392B";
        context.fillRect(30, 610, 10, 60);

        context.fillStyle = "#E74C3C";
        context.fillRect(0, 670, 90, 30);

        context.fillStyle = "#C0392B";
        context.fillRect(30, 660, 60, 10);

        //Prawy dolny

        context.fillStyle = "#E74C3C";
        context.fillRect(670, 610, 30, 90);

        context.fillStyle = "#C0392B";
        context.fillRect(660, 610, 10, 60);

        context.fillStyle = "#E74C3C";
        context.fillRect(610, 670, 60, 30);

        context.fillStyle = "#C0392B";
        context.fillRect(610, 660, 60, 10);

        /*
        var image = new Image();
        image.src = "../Content/Images/platformLeftRight.png";

        context.drawImage(image, 50, 50);
        */
    }
};

function drawPlatformBottom(offset) {
    var canvas = document.getElementById('canvas');
    if (canvas.getContext) {
        var context = canvas.getContext('2d');
        var image = new Image();
        image.src = "../Content/Images/platformLeftRight.png";

        context.clearRect(90, 660, 520, 40);

        context.drawImage(image, offset, 660);
    }
}

function drawPlatformTop(offset) {
    var canvas = document.getElementById('canvas');
    if (canvas.getContext) {
        var context = canvas.getContext('2d');
        var image = new Image();
        image.src = "../Content/Images/platformLeftRight.png";

        context.clearRect(90, 0, 520, 40);

        context.drawImage(image, (700 - offset) - 126, -5);
    }
}

function drawPlatformLeft(offset) {
    var canvas = document.getElementById('canvas');
    if (canvas.getContext) {
        var context = canvas.getContext('2d');
        var image = new Image();
        image.src = "../Content/Images/platformTopBottom.png";

        context.clearRect(0, 90, 40, 520);

        context.drawImage(image, -5, offset);
    }
}

function drawPlatformRight(offset) {
    var canvas = document.getElementById('canvas');
    if (canvas.getContext) {
        var context = canvas.getContext('2d');
        var image = new Image();
        image.src = "../Content/Images/platformTopBottom.png";

        context.clearRect(660, 90, 40, 520);

        context.drawImage(image, 660, (700-offset)-126);
    }
}

function drawWallTop() {
    var canvas = document.getElementById('canvas');
    if (canvas.getContext) {
        var context = canvas.getContext('2d');

        context.fillStyle = "#E74C3C";
        context.fillRect(0, 0, 700, 30);

        context.fillStyle = "#C0392B";
        context.fillRect(30, 30, 610, 10);
    }
}

function drawWallLeft() {
    var canvas = document.getElementById('canvas');
    if (canvas.getContext) {
        var context = canvas.getContext('2d');
        context.fillStyle = "#E74C3C";
        context.fillRect(0, 0, 30, 700);

        context.fillStyle = "#C0392B";
        context.fillRect(30, 30, 10, 610);
    }
}

function drawWallRight() {
    var canvas = document.getElementById('canvas');
    if (canvas.getContext) {
        var context = canvas.getContext('2d');
        context.fillStyle = "#E74C3C";
        context.fillRect(670, 0, 30, 700);

        context.fillStyle = "#C0392B";
        context.fillRect(660, 30, 10, 610);
    }
}