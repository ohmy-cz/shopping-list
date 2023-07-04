import { Suspense, useState, useEffect } from "react";
import "./App.css";
import {
  Avatar,
  Button,
  Modal,
  Space,
  Tabs,
  useMantineTheme,
} from "@mantine/core";
import { ShoppingList } from "./Areas/ShoppingList";
import { Recipes } from "./Areas/Recipes";
import styled from "@emotion/styled";
import { useTranslation } from "react-i18next";
import { Padding } from "./Components/Padding";
import { useDisclosure, useLocalStorage } from "@mantine/hooks";
import { User } from "./Shared/Interfaces/User";
import {
  HubConnection,
  HubConnectionBuilder,
  LogLevel,
} from "@microsoft/signalr";
import { EditUser } from "./Components/EditUser";

function App() {
  const [activeTab, setActiveTab] = useState<string | null>("shopping-list");
  const { t } = useTranslation();
  const [unlocked, setUnlocked] = useState(true);
  const [user, setUser] = useLocalStorage<User | undefined>({
    key: "user",
  });
  const [opened, { open, close }] = useDisclosure(false);
  const [connection, setConnection] = useState<HubConnection>();
  const [usersOnline, setUsersOnline] = useState<User[]>([]);
  const theme = useMantineTheme();
  const colors = Object.keys(theme.colors);

  useEffect(() => {
    const connection = new HubConnectionBuilder()
      .withUrl("/api/onlineusers")
      .configureLogging(LogLevel.Information)
      .withAutomaticReconnect()
      .build();

    setConnection(connection);
  }, []);

  useEffect(() => {
    if (!connection) {
      console.error("Invalid connection");
      return;
    }

    connection.on("UsersOnline", (users: User[]) => {
      setUsersOnline(users);
    });

    connection.on("User", (user: User) => {
      setUser(user);
    });

    connection
      .start()
      .then(() => {
        connection?.invoke(
          "Connect",
          user ?? {
            avatarColor: colors[Math.floor(Math.random() * colors.length)],
          },
        );
      })
      .catch(error => console.error(error));
  }, [connection]);

  return (
    <Suspense fallback="Loading...">
      <Layout>
        <header>
          {unlocked && (
            <>
              <Space h="sm" />
              <Tabs
                color="teal"
                value={activeTab}
                onTabChange={setActiveTab}
                variant="outline"
              >
                <Tabs.List position="center">
                  <Tabs.Tab value="shopping-list">
                    {t("shopping-list")}
                  </Tabs.Tab>
                  <Tabs.Tab value="recipes" color="blue">
                    {t("recipes")}
                  </Tabs.Tab>
                </Tabs.List>
              </Tabs>
              {user && connection && (
                <>
                  <RightTop>
                    <Button variant="subtle" compact onClick={open}>
                      Me&nbsp;
                      <Avatar size="sm" radius="xl" color={user.avatarColor}>
                        {user.initials}
                      </Avatar>
                    </Button>
                  </RightTop>
                  <Modal opened={opened} onClose={close} title="Change me">
                    <EditUser
                      connection={connection}
                      user={user}
                      onSave={close}
                    />
                  </Modal>
                </>
              )}
            </>
          )}
        </header>
        <Content>
          {activeTab === "recipes" ? (
            <Recipes />
          ) : (
            <ShoppingList
              unlocked={unlocked}
              setUnlocked={setUnlocked}
              usersOnline={usersOnline}
            />
          )}
        </Content>
      </Layout>
    </Suspense>
  );
}

const Layout = styled.div`
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  display: grid;
  grid-template-rows: auto 1fr;
`;

const Content = styled.main`
  position: relative;
`;

const RightTop = styled(Padding)`
  position: absolute;
  top: 0;
  right: 0;
  padding-top: 10px;
  padding-bottom: 0;
`;

export default App;
