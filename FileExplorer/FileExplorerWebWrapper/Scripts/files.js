function goToParent() {
    var textFilePath = document.getElementById("filePath");
    var filePath = textFilePath.value;
    if (filePath.lastIndexOf("\\") === filePath.indexOf("\\") && filePath.indexOf("\\") === filePath.length - 1) {
        textFilePath.value = "";
        getFileInfo();
        return;
    }
    if (filePath.lastIndexOf("\\") > 0) {
        if (filePath.lastIndexOf("\\") === filePath.length - 1)
            filePath = filePath.substr(0, filePath.length - 1);
        textFilePath.value = filePath.substr(0, filePath.lastIndexOf("\\") + 1);
        getFileInfo();
    }
}
function getFileInfo() {
    var nodeKeySelection = document.getElementById('keySelection');
    var selection = "Name";
    switch (nodeKeySelection.selectedIndex) {
        case 0:
            selection = "Name";
            break;
        case 1:
            selection = "CreationTime";
            break;
        case 2:
            selection = "Length";
    }
    var nodeFileList = document.getElementById('file-list');
    nodeFileList.innerHTML = '';
    var textFilePath = document.getElementById("filePath");
    var filePath = textFilePath.value;
    $.ajax({
        "type": "post",
        "url": "/Home/FileInfo",
        "data": {
            "filePath": filePath,
            "keyField": selection
        },
        "success": function (data) {
            var json = JSON.parse(JSON.stringify(data));
            if (json["Error"] != 0) {
                alert("发生了错误：\n" + json["Message"]);
                return;
            }
            if (json["Type"] === "Directory") {
                for (fileJson of json["FileList"])
                {
                    createFileNode(fileJson);
                }
                return;
            }

            var nodeFileTitle = document.createElement("h4");
            nodeFileTitle.style.color = "grey";
            nodeFileTitle.innerHTML = json["Name"];
            nodeFileList.appendChild(nodeFileTitle);
            nodeFileList.appendChild(document.createElement("hr"));

            if (json["Type"] === "Binary") {
                var nodePrompt = document.createElement("h5");
                nodePrompt.setAttribute("style", "color:grey");
                nodePrompt.innerHTML = "这是一个二进制文件...";
                nodeFileList.appendChild(nodePrompt);
            }
            else if (json["Type"] === "Text") {
                var nodePrompt = document.createElement("h5");
                nodePrompt.innerHTML = json["Content"].replace("\n", "&nbsp");
                nodeFileList.appendChild(nodePrompt);
            }
            else {
                var nodePrompt = document.createElement("h5");
                nodePrompt.setAttribute("style", "color:grey");
                nodePrompt.innerHTML = "不存在这个文件或者对文件的读写被拒绝...";
                nodeFileList.appendChild(nodePrompt);
            }
        }
    })
}

function createFileNode(fileJson) {
    var filename = fileJson["Name"];
    var creationTime = fileJson["CreationTime"];

    var nodeFileList = document.getElementById('file-list');
    var nodeFileAttrDiv = document.createElement('div');
    nodeFileAttrDiv.setAttribute('style', 'float:left; display:table-cell; vertical-align: middle; margin-left:8px');

    var nodeFileName = document.createElement('span');
    nodeFileName.className = 'h5 file-name';
    if (filename.length > 15) {
        filename = filename.substr(0, 14) + "...";
    }
    nodeFileName.innerHTML = filename;
    nodeFileName.setAttribute('style', 'max-width:200px');
    nodeFileAttrDiv.appendChild(nodeFileName);
    nodeFileAttrDiv.appendChild(document.createElement('br'));

    var nodeFileCreationTime = document.createElement('span');
    nodeFileCreationTime.className = 'h6 file-creation-time';
    nodeFileCreationTime.innerHTML = creationTime;
    nodeFileAttrDiv.appendChild(nodeFileCreationTime);

    var nodeDeleteBtn = document.createElement('img');
    nodeDeleteBtn.src = '/Content/delete_12.png';
    nodeDeleteBtn.setAttribute('style', 'padding:5px; float:right');
    nodeDeleteBtn.style.display = "none";
    nodeDeleteBtn.onclick = () => {
        const fp = fileJson['FullName'];
        $.ajax({
            "type": "post",
            "url": "/Home/Delete",
            "data": {
                "filePath": fp
            },
            "success": function (data) {
                var json = JSON.parse(JSON.stringify(data));
                if (json['Error'] !== 0) {
                    alert("删除时遇到了错误：\n错误代码：\n" + json['Error'] + "\n错误信息：" + data['Message']);
                }
                else {
                    // TODO   结果
                }
                getFileInfo();
            }
        })
    }
    
    if (fileJson["Length"]) {
        var nodeFileLength = document.createElement('span');
        nodeFileLength.className = 'h6 file-length';
        var unit = ["B", "KB", "MB", "GB", "TB", "EB"];
        var unitsize = 0;
        while (fileJson['Length'] >= 1024) {
            fileJson['Length'] /= 1024;
            unitsize += 1;
        }
        nodeFileLength.innerHTML = (fileJson['Length'] + "").substr(0, 4) + unit[unitsize];
        nodeFileAttrDiv.appendChild(nodeFileLength);
    }

    var nodeImg = document.createElement('img');
    if (fileJson["Length"]) {
        nodeImg.src = '/Content/file_32.png';
    }
    else {
        nodeImg.src = '/Content/folder_32.png';
    }
    nodeImg.setAttribute('style', 'padding:5px; float:left');

    var nodeHoverableDiv = document.createElement('div');
    nodeHoverableDiv.className = 'col-lg-3 col-md-4 col-sm-6 hoverable';
    nodeHoverableDiv.appendChild(nodeImg);
    nodeHoverableDiv.appendChild(nodeDeleteBtn);
    nodeHoverableDiv.appendChild(nodeFileAttrDiv);
    nodeHoverableDiv.setAttribute('fullPath', fileJson['FullName']);

    nodeHoverableDiv.ondblclick = () => {
        const fp = fileJson['FullName'];
        var textFilePath = document.getElementById("filePath");
        textFilePath.value = fp;
        getFileInfo();
    }

    nodeHoverableDiv.onmouseenter = () => {
        nodeDeleteBtn.style.display = "block";
    }

    nodeHoverableDiv.onmouseleave = () => {
        nodeDeleteBtn.style.display = "none";
    }

    nodeFileList.appendChild(nodeHoverableDiv);
}
$(document).ready(() => {
    getFileInfo();
});