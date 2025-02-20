


//<div class="middlecontent">
//    <div class="container" id="chatgptcontainer" style="">
//        <div class="col-md-12">
//            <div class="wow fadeInDown" style="visibility: visible; animation-name: fadeInDown;text-align:justify; " data-wow-animation-name="fadeInDown">
//                <div class="card-header" style="text-align: center; font-family: monospace; font-weight: 600; font-size: larger; margin-top: 15px; ">

//                    Hi,i am <span style=" color: #145ca6; font-weight: 600;">Anthem</span> OpenAI &#x1F916; Ask Me Anything !
//                </div>
//                <div class="input-group" id="chatgptinput" style="">
//                    <input type="text" id="user-message" class="form-control" placeholder="Type your Question...">
//                        <div class="input-group-append" style=" margin-left: 10px;">
//                            <button id="send-button" class="btn btn-primary" style=" background-color: #009cff">Ask</button>
//                        </div>

//                </div>
//                <div id="response-div" class="card" style="border-radius: 15px; margin-top: 20px;  display: none;">
//                    <div class="chat-container2" id="message-list"></div>
//                </div>
//            </div>
//        </div>
//    </div>
//</div>

const API_URL = "https://api.openai.com/v1/chat/completions";
//const API_KEY = "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";
  const API_KEY = "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";
const systemMessage = {
    role: "system",
    //content: "Answer only information technology Question If other question as Give sorry message"
    content: "Answer only information technology questions. If you have a different question, I'll give a sorry message."
};

let messages = [];



//async function sendMessage1() {
//    const userMessage = document.getElementById("user-message").value;
//    document.getElementById("user-message").value = "";
//    //console.log('test', userMessage)
//    localStorage.setItem("userQuestion", userMessage); // Save user question

//    const responseDiv = document.getElementById("response-div");

//    if (userMessage.trim() !== "") {
//        responseDiv.style.display = "block";
//    } else {
//        responseDiv.style.display = "none";
//    }
//    // Clear the previous chat history
//    messages = [];
//    if (userMessage.trim() !== "") {
//    await processMessageToChatGPT(userMessage);
//    } else {
//        renderMessages();
//    }
//    renderMessages();
//}

async function sendMessage1() {
    const userMessage = document.getElementById("user-message").value;
    document.getElementById("user-message").value = "";
    //console.log('test', userMessage)
    localStorage.setItem("userQuestion", userMessage); // Save user question

    const responseDiv = document.getElementById("response-div");

    if (userMessage.trim() !== "") {
        responseDiv.style.display = "block";
    } else {
        responseDiv.style.display = "none";
    }
    messages = [];

    const isAnthemQuestion = userMessage.toLowerCase().includes("anthem infotech");
    const isYourCompanyQuestion = userMessage.toLowerCase().includes("your company");

    if (isAnthemQuestion || isYourCompanyQuestion) {
        const anthemResponse = "We have been working in the industry since 2011. We are specialized mainly in Microsoft technologies (Asp.net/ Asp.net MVC/ Asp.net Core/ MS SQL Server/ .Net Framework / Azure / C#.Net). We thrive on building Enterprise Solutions, Software Products, B2B applications and lot more that help people and businesses to compete and perform better. Our approach is to understand requirements thoroughly, ask the suitable questions to prepare best plan, executing it in timely manner with customer feedback and to produce a best solution. Our Office Address is #11, Floor 11, Sushma Infinium, Chandigarh - Ambala Highway, Near Best Price Zirakpur, Punjab – 140603 India.";
        const newMessageAnthem = {
            message: anthemResponse,
            sender: "ChatGPT"
        };
        messages.push(newMessageAnthem);
        renderMessages();
    } else {
        const questionPatterns = [
            /anthem/i, // Matches any question containing the word "anthem" (case-insensitive)
            /your\s+company/i // Matches questions like "your company" (case-insensitive)
            // Add more patterns as needed, use /pattern/i for case-insensitive matching
        ];

        // Check if the user's message matches any of the question patterns
        const isSpecialQuestion = questionPatterns.some((pattern) => pattern.test(userMessage));
        if (isSpecialQuestion) {
            // Respond with the general answer for special questions
            const specialResponse = "Anthem is a software company. Address #11, Floor 11, Sushma Infinium, Chandigarh - Ambala Highway, Near Best Price Zirakpur, Punjab – 140603 India.";
            const newMessageSpecial = {
                message: specialResponse,
                sender: "ChatGPT"
            };
            messages.push(newMessageSpecial);
            renderMessages();
        } else {
            // Proceed with the regular API call to ChatGPT for other questions
            if (userMessage.trim() !== "") {
                await processMessageToChatGPT(userMessage);
            } else {
                renderMessages();
            }
        }
    }
}




//async function sendMessage1() {
//    const userMessage = document.getElementById("user-message").value;
//    document.getElementById("user-message").value = "";
//    //console.log('test', userMessage)
//    localStorage.setItem("userQuestion", userMessage); // Save user question

//    const responseDiv = document.getElementById("response-div");

//    if (userMessage.trim() !== "") {
//        responseDiv.style.display = "block";
//    } else {
//        responseDiv.style.display = "none";
//    }
//    messages = [];

//    const isAnthemQuestion = userMessage.toLowerCase().includes("anthem infotech");
//    if (isAnthemQuestion) {
//        const anthemResponse = "We have been working in the industry since 2011. We are specialized mainly in Microsoft technologies (Asp.net/ Asp.net MVC/ Asp.net Core/ MS SQL Server/ .Net Framework / Azure / C#.Net). We thrive on building Enterprise Solutions, Software Products, B2B applications and lot more that help people and businesses to compete and perform better. Our approach is to understand requirements thoroughly, ask the suitable questions to prepare best plan, executing it in timely manner with customer feedback and to produce a best solution. Our Office Address is #11, Floor 11, Sushma Infinium, Chandigarh - Ambala Highway, Near Best Price Zirakpur, Punjab – 140603 India.";
//        const newMessageAnthem = {
//            message: anthemResponse,
//            sender: "ChatGPT"
//        };
//        messages.push(newMessageAnthem);
//        renderMessages();
//    } else {
//        if (userMessage.trim() !== "") {
//            await processMessageToChatGPT(userMessage);
//        } else {
//            renderMessages();
//        }
//    }
//}


let isTyping = false;



async function processMessageToChatGPT(userMessage) {
    isTyping = true;

    const apiMessages = [
        systemMessage,
        { role: "user", content: userMessage }
    ];

    const apiRequestBody = {
        model: "gpt-3.5-turbo",
        messages: apiMessages
    };

    $.ajax({
        url: API_URL,
        type: "POST",
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Bearer " + API_KEY);
            xhr.setRequestHeader("Content-Type", "application/json");
        },
        data: JSON.stringify(apiRequestBody),
        success: function (data) {
            const newMessage = {
                message: data.choices[0].message.content,
                sender: "ChatGPT"
            };

            messages.push(newMessage);
            isTyping = false;
            renderMessages();
        },
        error: function (error) {
            console.log("Error:", error);
        }
    });
}

function renderMessages() {
    const messageList = document.getElementById("message-list");
    messageList.innerHTML = "";
    if (messages.length > 0) {
        messages.forEach((message) => {
            if (message.sender === "ChatGPT") {
                const messageItem = document.createElement("div");
                messageItem.classList.add("message-item");
                messageItem.classList.add("incoming");
                const fullMessages = message.message;
                localStorage.setItem("userAnswer", fullMessages); // Save user question

                const content = document.createElement("div");
                content.classList.add("content");
                //console.log('test message', message)
                // Check if the message is longer than 5 words
                if (message.message.split(" ").length > 30) {
                    const truncatedMessage = message.message.split(" ").slice(0, 30).join(" ");
                    const fullMessage = message.message;

                    content.innerHTML = `${truncatedMessage}  <span class="read-more" data-url="/home/ChatBot">Read More...</span>`;
                    content.setAttribute("data-full-message", fullMessage);
                } else {
                    content.textContent = message.message;
                }

                messageItem.appendChild(content);
                messageList.appendChild(messageItem);
            }
        });
    }

             else {
            // Display "Wait" message if there are no messages
            showWaitMessage();
        }
    }

function showFullMessage(linkElement) {
    const contentDiv = linkElement.parentElement;
    const fullMessage = contentDiv.getAttribute("data-full-message");
    contentDiv.innerHTML = fullMessage;
}

function showWaitMessage() {
    const messageList = document.getElementById("message-list");
    messageList.innerHTML = '<div class="spinner-border text-primary" role="status" style="margin-left: 10px;"><p style="color: #aaa;font - style: italic;">Anthem Ai is typing...</p></div>';
}
//document.getElementById("send-button").addEventListener("click", sendMessage);

document.getElementById("send-button").addEventListener("click", function () {


   

    sendMessage1();
});


document.addEventListener("click", function (event) {
    if (event.target.classList.contains("read-more")) {
        const fullMessage = event.target.parentNode.getAttribute("data-full-message");
        localStorage.setItem("fullMessage", fullMessage);
        const url = event.target.getAttribute("data-url");
        window.open(url, "_blank"); // Open a new tab with the specified URL
    }
});


//document.getElementById("user-message").addEventListener("keydown", function (event) {
//    if (event.key === "Enter") {
//        sendMessage();
//    }
//});

document.addEventListener("DOMContentLoaded", () => {
    renderMessages();
});

//this is the function of details save in database
document.getElementById('send-button').addEventListener('click', () => {
    // Fetch the IP address from the API
    fetch('https://api.ipify.org?format=json')
        .then((response) => response.json())
        .then((data) => {
            // Get the user's input value
            const userQuestion1 = localStorage.getItem("userQuestion");

            // Log the IP address and the input value to the console
            //console.log('Your IP address is:', data.ip);
            //console.log('User Message:', userQuestion1);
            //const browserInfo = `${navigator.userAgent} - ${navigator.platform}`;
            //console.log('User Browser Info:', browserInfo);
            // Prepare the data to send to the server
            const formData = new FormData();
            formData.append('IPAddress', data.ip);
            formData.append('Question', userQuestion1);

            // Make an HTTP POST request to the controller
            fetch('/Home/SendEmailforChatgpt', {
                method: 'POST',
                body: formData
            })
                .then((response) => {
                    // Handle the response from the server if needed
                   console.log('Saved');
                })
                .catch((error) => {
                    console.error('Error sending data to the server:', error);
                });
        })
        .catch((error) => {
            console.error('Error fetching IP address:', error);
        })
    
});