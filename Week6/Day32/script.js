const form = document.querySelector('.form');
let data = [];

function getCommentData() {
    const userName = document.querySelector('input[name="name"]');
    const userAge = document.querySelector('input[name="age"]');
    const userRating = document.querySelector('select[name="rating"]');
    const userComment = document.querySelector('textarea[name="comment"]');

    const userStats = { name: userName.value, age: userAge.value, rating: userRating.value, comment: userComment.value };

    return userStats;
}

window.addEventListener('load', async (event) => {
    try {
        const response = await fetch('./data/demo.json', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            },
        });

        if (!response.ok) {
            throw new Error('Something went wrong');
        }

        data = await response.json();

        data.forEach((element) => {
            const ratingContainer = document.getElementById('comments-container');
            ratingContainer.prepend(fillCommentBox(element));
        });
    } catch (err) {
        console.log(err);
    }
});

form.addEventListener('submit', (event) => {
    const commentsData = getCommentData();
    const ratingContainer = document.getElementById('comments-container');

    try {
        event.preventDefault();
        const errorSpan = document.createElement('span');

        if (commentsData.name == '' || commentsData.age == '' || commentsData.rating == '' || commentsData.comment == '') {
            errorSpan.innerHTML = fillSpan('All fields are required!', 'error-msg-show');
            document.getElementById('submit-btn').parentElement.append(errorSpan);
            throw new Error('All fields are required!');
        }

        if (commentsData.name !== 0 && commentsData.age !== 0 && commentsData.rating !== 0 && commentsData.comment !== 0) {
            const errorElements = document.querySelectorAll('.error-msg-show');
            if (errorElements.length > 0) {
                errorElements.forEach((errorElement) => {
                    errorElement.classList.add('error-msg-hide');
                });
            }
        }

        console.log(commentsData);
        for (const key in commentsData) {
            commentsData[key] = '';
        }

        ratingContainer.prepend(fillCommentBox(getCommentData()));

        for (const key in commentsData) {
            const element = document.querySelector(`[name="${key}"]`);
            if (element) {
                element.value = '';
            }
        }
    } catch (err) {
        console.log(err);

        for (const key in commentsData) {
            commentsData[key] = '';
        }
    }
});

function fillCommentBox(commentData) {
    const commentBox = document.createElement('article');
    commentBox.classList.add('comment-section');

    const userStats = document.createElement('p');
    userStats.classList.add('user-details');
    userStats.innerHTML = `${fillSpan(commentData.name, 'user-name')},${fillSpan(commentData.age, 'user-age')} ${fillSpan(commentData.rating, 'user-rating')}`;
    commentBox.appendChild(userStats);

    const commentParagr = document.createElement('p');
    commentParagr.classList.add('user-comment');
    commentParagr.innerHTML = `${commentData.comment}`;
    commentBox.appendChild(commentParagr);

    return commentBox;
}

function fillSpan(info, className) {
    return `<span class="${className}">${info}</span>`;
}
