import {
  ActionIcon,
  Avatar,
  Button,
  Center,
  Checkbox,
  Group,
  MediaQuery,
  NativeSelect,
  ScrollArea,
  SimpleGrid,
  TextInput,
  useMantineTheme,
} from "@mantine/core";
import styled from "@emotion/styled";
import { Padding } from "../Components/Padding";
import { useTranslation } from "react-i18next";
import { ItemGroup } from "./ShoppingList.ItemGroup";
import { useListState, randomId, useLocalStorage } from "@mantine/hooks";
import {
  IconArrowLeft,
  IconArrowRight,
  IconLock,
  IconLockOpen,
  IconSearch,
} from "@tabler/icons-react";
import { OnlineUsers } from "../Components/OnlineUsers";
import { User } from "../Shared/Interfaces/User";
import { useEffect, useState } from "react";
import { ShoppingList as ShoppingListModel } from "../Models/ShoppingList";

const vegetables = [
  { label: "Brocolli", checked: true, key: randomId() },
  { label: "Bananas", checked: false, key: randomId() },
  { label: "Onions", checked: false, key: randomId() },
];

const meats = [
  { label: "Chicken breast", checked: true, key: randomId() },
  { label: "Hacked beef", checked: false, key: randomId() },
  { label: "Salmon fillet", checked: false, key: randomId() },
  { label: "Pork chops", checked: false, key: randomId() },
  { label: "Sausages", checked: false, key: randomId() },
];

interface ShoppingListProps {
  unlocked: boolean;
  setUnlocked: (value: boolean) => void;
  usersOnline: User[];
}

export const ShoppingList = ({
  unlocked,
  setUnlocked,
  usersOnline,
}: ShoppingListProps) => {
  const [vegetableValues, vegetableHandlers] = useListState(vegetables);
  const [meatValues, meatHandlers] = useListState(meats);
  const { t } = useTranslation();
  const theme = useMantineTheme();
  const [user] = useLocalStorage<User | undefined>({
    key: "user",
  });
  const [shoppingList, setShoppingList] = useState<
    ShoppingListModel | undefined
  >();

  useEffect(() => {
    fetch("/api/Home?code=ABC")
      .then(res => res.json())
      .then(
        result => {
          // console.log(result);
          // alert(result.message);

          // setIsLoaded(true);
          setShoppingList(result);
          console.log(result.shop);
          console.log(result.shop.itemCategories);
          console.log("--- HERE ---");
          console.log(shoppingList?.shop.itemCategories);
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          console.error(error);
          // setIsLoaded(true);
          // setError(error);
        },
      );
  }, []);
  return (
    <>
      <Layout>
        <ScrollArea>
          <Padding>
            {shoppingList?.shop.itemCategories &&
              shoppingList?.shop.itemCategories.map(category => (
                <ItemGroup
                  key={category.itemCategory.id}
                  icon="🥦"
                  name={category.itemCategory.name}
                >
                  {category.itemCategory.items &&
                    category.itemCategory.items.map((item, index) => (
                      <Group key={item.id}>
                        <Checkbox
                          mt="xs"
                          ml={33}
                          label={item.name}
                          checked={true}
                          onChange={event =>
                            vegetableHandlers.setItemProp(
                              index,
                              "checked",
                              event.currentTarget.checked,
                            )
                          }
                        />
                        <div>
                          {true && user && (
                            <Avatar
                              radius="xl"
                              size="sm"
                              color={user.avatarColor}
                            >
                              {user.initials}
                            </Avatar>
                          )}
                        </div>
                      </Group>
                    ))}
                </ItemGroup>
              ))}
            {/* <ItemGroup icon="🥦" name="Vegetables">
              {vegetableValues.map((value, index) => (
                <Group key={value.key}>
                  <Checkbox
                    mt="xs"
                    ml={33}
                    label={value.label}
                    checked={value.checked}
                    onChange={event =>
                      vegetableHandlers.setItemProp(
                        index,
                        "checked",
                        event.currentTarget.checked,
                      )
                    }
                  />
                  <div>
                    {value.checked && user && (
                      <Avatar radius="xl" size="sm" color={user.avatarColor}>
                        {user.initials}
                      </Avatar>
                    )}
                  </div>
                </Group>
              ))}
            </ItemGroup>
            <ItemGroup icon="🥓" name="Meat">
              {meatValues.map((value, index) => (
                <Group key={value.key}>
                  <Checkbox
                    mt="xs"
                    ml={33}
                    label={value.label}
                    checked={value.checked}
                    onChange={event =>
                      meatHandlers.setItemProp(
                        index,
                        "checked",
                        event.currentTarget.checked,
                      )
                    }
                  />
                  <div>
                    {value.checked && user && (
                      <Avatar radius="xl" size="sm" color={user.avatarColor}>
                        {user.initials}
                      </Avatar>
                    )}
                  </div>
                </Group>
              ))}
            </ItemGroup> */}
            {user?.id}
            <TextInput
              icon={<IconSearch size="1.1rem" stroke={1.5} />}
              radius="xl"
              size="md"
              rightSection={
                <ActionIcon
                  size={32}
                  radius="xl"
                  color={theme.primaryColor}
                  variant="filled"
                >
                  {theme.dir === "ltr" ? (
                    <IconArrowRight size="1.1rem" stroke={1.5} />
                  ) : (
                    <IconArrowLeft size="1.1rem" stroke={1.5} />
                  )}
                </ActionIcon>
              }
              placeholder="Search questions"
              rightSectionWidth={42}
            />
          </Padding>
        </ScrollArea>
        <Footer>
          <Padding>
            {unlocked ? (
              <SimpleGrid cols={2}>
                <NativeSelect
                  data={[
                    "REMA 1000 - Frederiksundsvej",
                    "Lidl - Frederiksundsvej",
                    "Føtex - Frederiksundsvej",
                    "Føtex - BIG",
                  ]}
                  label="Where you want to shop?"
                />
                <MediaQuery largerThan="lg" styles={{ display: "none" }}>
                  <Button
                    leftIcon={<IconLock />}
                    size="xl"
                    onClick={() => setUnlocked(false)}
                  >
                    {t("start-shopping-short")}
                  </Button>
                </MediaQuery>
                <MediaQuery smallerThan="lg" styles={{ display: "none" }}>
                  <Button
                    leftIcon={<IconLock />}
                    size="xl"
                    onClick={() => setUnlocked(false)}
                  >
                    {t("start-shopping-long")}
                  </Button>
                </MediaQuery>
              </SimpleGrid>
            ) : (
              <Center>
                <Button
                  onClick={() => setUnlocked(true)}
                  color="secondary"
                  size="xs"
                  leftIcon={<IconLockOpen />}
                >
                  Unlock
                </Button>
              </Center>
            )}
          </Padding>
        </Footer>
      </Layout>
      <OnlineUsers usersOnline={usersOnline} />
    </>
  );
};

const Layout = styled.div`
  display: grid;
  grid-template-rows: 1fr auto;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
`;

const Footer = styled.div`
  border-top: 1px solid
    ${({ theme }) =>
      theme.colorScheme === "dark"
        ? theme.colors.dark[6]
        : theme.colors.gray[2]};
`;
