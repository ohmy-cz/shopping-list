# Shopping list

## Plan your grocery list, with your partner, in realtime.

When it's time to go to the store, share the list with your partner (and kids) and ask them to get groceries from different categories - save time on the mundane.

You'll see immediately what has been added to the shopping cart, as they tick items off the list - so nothing gets added twice, and nothing is forgotten. The screen will also stay lit, preventing it from going to sleep every few seconds.

**_No_ logins required. _No_ ads. _No_ tracking.** You can host this app on your Raspberry PI, if you want to.

## Features

### Currently implemented

- See online users in realtime
- Change your avatar's initials and color

### To-do (in order of priority)

- See if somebody starts adding an item to the list in realtime, with their avatar displayed
- Persist the shopping list in a database
- Add a shopping list clear button
- Add the always-on shimmy
- Introduce groups, so different families can start using the app
- Persist food groups by a selected grocery store.
- Add user-managed list of recipes

## Development

### Starting the project

- Have Docker installed, and this repository cloned
- Run `docker compose up`
- Enter `http://localhost:666` in your browser

### Testing on LAN

To test the project on LAN, start the project and then apply the following command (Windows):

```cmd
netsh interface portproxy add v4tov4 listenport=80 connectaddress=localhost connectport=666 protocol=tcp
```

then, you'll be able to access the app using your host computer's IP address.
