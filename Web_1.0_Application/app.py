from flask import (Flask, redirect, render_template, request)
from contacts_model import (Contact)

Contact.load_db()

app=Flask(__name__)

@app.route('/')
def index():
    return redirect('/contacts')

@app.route('/contacts')
def contacts():
    search = request.args.get("q")
    if search is not None:
        contacts_set = Contact.search(search)
    else:
        contacts_set = Contact.all()
    return render_template("index.html", contacts=contacts_set)

@app.route("/contacts/new", methods=['GET'])
def contacts_new_get():
    return render_template("new.html", contact=Contact())

@app.route("/contacts/new", methods=['POST'])
def contacts_new():
    c = Contact(None, request.form['first_name'], request.form['last_name'], request.form['phone'],
                request.form['email'])
    if c.save():
        flash("Created New Contact!")
        return redirect("/contacts")
    else:
        return render_template("new.html", contact=c)


if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0')
